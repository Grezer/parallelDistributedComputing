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
        bool draggedNow = false;
        Point leftAnglePosition;
        double scale = 2;
        Point oldMousePosition;
        int[,] arrayOfDepths = new int[1000, 1000];
        Complex[,] arrayOfCoord = new Complex[1000, 1000];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        public void redraw()
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(1000, 1000);
            startArrayOfCoord();
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
                    bm.SetPixel(i, j, Color.FromArgb(arrayOfDepths[i, j], arrayOfDepths[i, j], arrayOfDepths[i, j]));

            /*
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double a = (double)(x - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width / 4);
                    double b = (double)(y - (pictureBox1.Height / 2)) / (double)(pictureBox1.Height / 4);
                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);
                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z += c;
                        if (z.Magnitude() > 2.0)
                            break;
                    } while (it < 100);
                    bm.SetPixel(x, y, it < 100 ? Color.Black : Color.White);
                }
            }
            */
            pictureBox1.Image = bm;
        }

        public void startArrayOfCoord()
        {
            for (int i = 0; i < arrayOfCoord.GetLength(0); i++)
                for (int j = 0; j < arrayOfCoord.GetLength(1); j++)
                {
                    double a = (double)(i - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width / 4);
                    double b = (double)(j - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width / 4);
                    arrayOfCoord[i, j] = new Complex(a, b);            
                }
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
            draggedNow = false;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draggedNow = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if(draggedNow)
            //{
            //    int changeX = e.X - oldMousePosition.X;
            //    int changeY = e.Y - oldMousePosition.Y;
            //    for (int i = 0; i < 1000; i++)
            //        for (int j = 0; j < 1000; j++)
            //        {
            //            double part = 1000 / scale;                            
            //            Complex newCoodr = new Complex(arrayOfCoord[i, j].a + part * changeX, arrayOfCoord[i, j].b + part * changeY);
            //            arrayOfCoord[i, j] = newCoodr;
            //        }
            //}
            //change coord
        }
    }
}
