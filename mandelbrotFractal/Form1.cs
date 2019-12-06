using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace mandelbrotFractal
{
    public partial class Form1 : Form
    {
        int[,] arrayOfDepths = new int[600, 600];
        Complex[,] arrayOfCoord = new Complex[600, 600];
        Point startPoint, finishPoint;
        bool mousePressed;
        Bitmap bm = new Bitmap(600, 600);
        Bitmap mbm = new Bitmap(600, 600);
        int minX, maxX, minY, maxY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Complex startMin = new Complex(-2.0, -2.0);
            Complex startMax = new Complex(2.0, 2.0);
            startArrayOfCoord(startMin, startMax);
            redraw();
        }

        private void redraw()
        {
            Task[] tasks = new Task[4];
            for (int i = 0; i < 4; i++)
            {
                var counterOfDepths = new Task((param) =>
                {
                    Point p = new Point((arrayOfDepths.GetLength(0) / 4) * (int)param, (arrayOfDepths.GetLength(0) / 4) * (int)param + (arrayOfDepths.GetLength(0) / 4));
                    getDepths(p);
                }, i);
                tasks[i] = counterOfDepths;
            }
            foreach (var item in tasks)
                item.Start();
            Task.WaitAll(tasks);

            for (int i = 0; i < pictureBox1.Height; i++)
                for (int j = 0; j < pictureBox1.Width; j++)
                {
                    //if(arrayOfDepths[i, j] < 200)
                    //    bm.SetPixel(i, j, Color.FromArgb(0, 0, arrayOfDepths[i, j]));
                    //else
                        bm.SetPixel(i, j, Color.FromArgb(arrayOfDepths[i, j], arrayOfDepths[i, j], arrayOfDepths[i, j]));
                }
            pictureBox1.Image = bm;
        }

        public void startArrayOfCoord(Complex minPoint, Complex maxPoint)
        {
            double step = (maxPoint.a - minPoint.a) / arrayOfCoord.GetLength(0);
            for (int i = 0; i < arrayOfCoord.GetLength(0); i++)
                for (int j = 0; j < arrayOfCoord.GetLength(1); j++)
                {
                    double a = (step * i) + minPoint.a;
                    double b = (step * j) + minPoint.b;
                    arrayOfCoord[i, j] = new Complex(a, b);            
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Complex startMin = new Complex(-2.0, -2.0);
            Complex startMax = new Complex(2.0, 2.0);
            startArrayOfCoord(startMin, startMax);
            redraw();
        }

        public void getDepths(Point p) //p.X - start line, p.Y - finish line
        {
            for(int i = p.X; i < p.Y; i++)            
                for (int j = 0; j < arrayOfCoord.GetLength(1); j++)
                {
                    Complex c = arrayOfCoord[i, j];
                    Complex z = new Complex(0, 0);
                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z += c;
                        if (z.Magnitude() > 2.0)
                            break;
                    } while (it < 255);
                    arrayOfDepths[i, j] = it;
                }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
            finishPoint = new Point(e.X, e.Y);
            int range = Math.Max(maxX - minX, maxY-minY);
            Complex minPoint = new Complex(arrayOfCoord[minX, minY].a, arrayOfCoord[minX, minY].b);
            Complex maxPoint = new Complex(arrayOfCoord[minX + range, minY + range].a, arrayOfCoord[minX + range, minY + range].b);
            startArrayOfCoord(minPoint, maxPoint);
            redraw();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < pictureBox1.Height; i++)
                for (int j = 0; j < pictureBox1.Width; j++)
                {
                    //if (arrayOfDepths[i, j] < 200)
                    //    mbm.SetPixel(i, j, Color.FromArgb(0, 0, arrayOfDepths[i, j]));
                    //else
                        mbm.SetPixel(i, j, Color.FromArgb(arrayOfDepths[i, j], arrayOfDepths[i, j], arrayOfDepths[i, j]));
                }

            mousePressed = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                minX = Math.Min(startPoint.X, e.X);
                minY = Math.Min(startPoint.Y, e.Y);
                maxX = Math.Max(startPoint.X, e.X);
                maxY = Math.Max(startPoint.Y, e.Y);
               
                bm = (Bitmap)mbm.Clone();
                for (int i = minX; i < maxX; i++)
                {
                    bm.SetPixel(i, minY, Color.Red);
                    bm.SetPixel(i, maxY, Color.Red);
                }
                for (int i = minY; i < maxY; i++)
                {
                    bm.SetPixel(minX, i, Color.Red);
                    bm.SetPixel(maxX, i, Color.Red);
                }
                pictureBox1.Image = bm;
            }
        }
    }
}
