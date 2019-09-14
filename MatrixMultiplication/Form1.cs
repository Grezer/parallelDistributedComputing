using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixMultiplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] firstMatrix;
        int[,] secondMatrix;
        int[,] resultMatrix;
        Label[,] firstMatrixLabels;
        Label[,] secondMatrixLabels;
        Label[,] resMatrixLabels;
        int matrixSize;

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); panel2.Controls.Clear(); panel3.Controls.Clear();
            Random rnd = new Random();
            matrixSize = Convert.ToInt32(textBox1.Text);
            int n = matrixSize * 20 + 5 * (matrixSize - 1);
            panel1.Size = new Size(n, n); panel2.Size = new Size(n, n); panel3.Size = new Size(n, n);
            panel2.Location = new Point(n + 40, 40); panel3.Location = new Point(n * 2 + 60, 40);
            label2.Location = new Point(n + 20, 30 + n / 2); label2.Text = "X";
            label3.Location = new Point(n * 2 + 45, 30 + n / 2); label3.Text = "=";
            firstMatrix = new int[matrixSize, matrixSize];
            secondMatrix = new int[matrixSize, matrixSize];
            resultMatrix = new int[matrixSize, matrixSize];
            firstMatrixLabels = new Label[matrixSize, matrixSize];
            secondMatrixLabels = new Label[matrixSize, matrixSize];
            resMatrixLabels = new Label[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
                for (int j = 0; j < matrixSize; j++)
                {
                    firstMatrix[i, j] = rnd.Next(1, 4);
                    firstMatrixLabels[i, j] = new Label();
                    firstMatrixLabels[i, j].Text = firstMatrix[i, j].ToString();
                    firstMatrixLabels[i, j].Size = new Size(20, 20);
                    firstMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                    panel1.Controls.Add(firstMatrixLabels[i, j]);
                }

            for (int i = 0; i < matrixSize; i++)
                for (int j = 0; j < matrixSize; j++)
                {
                    secondMatrix[i, j] = rnd.Next(1, 4);
                    secondMatrixLabels[i, j] = new Label();
                    secondMatrixLabels[i, j].Text = secondMatrix[i, j].ToString();
                    secondMatrixLabels[i, j].Size = new Size(20, 20);
                    secondMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                    panel2.Controls.Add(secondMatrixLabels[i, j]);

                }

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < matrixSize; i++)            
                for (int j = 0; j < matrixSize; j++)
                {
                    Task<int> task1 = new Task<int>(() => getResult(i, j));
                    tasks.Add(new Task(delegate {
                        getResult(i, j);
                    }));
                    
                    //resultMatrix[i, j] = getResult(i, j);
                    //resMatrixLabels[i, j] = new Label();
                    //resMatrixLabels[i, j].Text = resultMatrix[i, j].ToString();
                    //resMatrixLabels[i, j].Size = new Size(20, 20);
                    //resMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                    //panel3.Controls.Add(resMatrixLabels[i, j]);
                }

            foreach (var i in tasks)
            {
                i.Start();
            }
        }

        public void getResult(int x, int y)
        {
            int res = 0;
            for (int i = 0; i < matrixSize; i++)           
                res += firstMatrix[i, y] * secondMatrix[x, i];
            resultMatrix[x, y] = res;
            resMatrixLabels[x, y] = new Label();
            resMatrixLabels[x, y].Text = res.ToString();
            resMatrixLabels[x, y].Size = new Size(20, 20);
            resMatrixLabels[x, y].Location = new Point(y * 25, x * 25);
            panel3.Controls.Add(resMatrixLabels[x, y]);
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (int.TryParse(textBox1.Text, out var x) ? true : false);
        }
    }
}
