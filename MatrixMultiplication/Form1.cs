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

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); panel2.Controls.Clear(); panel3.Controls.Clear();
            Random rnd = new Random();
            int matrixSize = Convert.ToInt32(textBox1.Text);
            int n = matrixSize * 20 + 5 * (matrixSize - 1);
            panel1.Size = new Size(n, n); panel2.Size = new Size(n, n); panel3.Size = new Size(n, n);
            panel2.Location = new Point(n + 40, 40); panel3.Location = new Point(n * 2 + 60, 40);
            label2.Location = new Point(n + 20, 30 + n / 2); label2.Text = "X";
            label3.Location = new Point(n * 2 + 45, 30 + n / 2); label3.Text = "=";
            int[,] firstMatrix = new int[matrixSize, matrixSize];
            int[,] secondMatrix = new int[matrixSize, matrixSize];
            int[,] resultMatrix = new int[matrixSize, matrixSize];
            Label[,] firstMatrixLabels = new Label[matrixSize, matrixSize];
            Label[,]secondMatrixLabels = new Label[matrixSize, matrixSize];
            Label[,] resMatrixLabels = new Label[matrixSize, matrixSize];

            //Генерация матриц
            for (int i = 0; i < matrixSize; i++)
                for (int j = 0; j < matrixSize; j++)
                {
                    firstMatrix[i, j] = rnd.Next(1, 4);
                    firstMatrixLabels[i, j] = new Label();
                    firstMatrixLabels[i, j].Text = firstMatrix[i, j].ToString();
                    firstMatrixLabels[i, j].Size = new Size(20, 20);
                    firstMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                    panel1.Controls.Add(firstMatrixLabels[i, j]);

                    secondMatrix[i, j] = rnd.Next(1, 4);
                    secondMatrixLabels[i, j] = new Label();
                    secondMatrixLabels[i, j].Text = secondMatrix[i, j].ToString();
                    secondMatrixLabels[i, j].Size = new Size(20, 20);
                    secondMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                    panel2.Controls.Add(secondMatrixLabels[i, j]);

                    resMatrixLabels[i, j] = new Label();
                    resMatrixLabels[i, j].Size = new Size(20, 20);
                    resMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                    panel3.Controls.Add(resMatrixLabels[i, j]);
                }      
            
            //Создание массива тасков
            Task[] tasks = new Task[matrixSize * matrixSize];
            for (int t = 0; t < matrixSize * matrixSize; t++)
            {
                var multiplicacion = new Task((param) =>
                {
                    int y = (int)param / matrixSize;
                    int x = (int)param % matrixSize;
                    resultMatrix[y, x] = 0;
                    for (int i = 0; i < matrixSize; i++)
                        resultMatrix[y, x] += firstMatrix[y, i] * secondMatrix[i, x];
                }, t);
                tasks[t] = multiplicacion;               
            }
            
            //Запуск всех тасков
            foreach (var item in tasks)            
                item.Start();
            Task.WaitAll(tasks);

            //Отображение результатов
            for (int i = 0; i < matrixSize; i++)
                for (int j = 0; j < matrixSize; j++)
                    resMatrixLabels[i, j].Text = resultMatrix[i, j].ToString();
        }        
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //Проверка на дурака
            button1.Enabled = (int.TryParse(textBox1.Text, out var x) ? true : false);
        }
    }
}
