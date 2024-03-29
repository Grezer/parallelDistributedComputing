﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
            int showMatrixSize = matrixSize >= 5 ? 5 : matrixSize;
            int n = showMatrixSize * 20 + 5 * (showMatrixSize - 1);
            panel1.Size = new Size(n, n); panel2.Size = new Size(n, n); panel3.Size = new Size(n + 100, n);
            panel2.Location = new Point(n + 40, 40); panel3.Location = new Point(n * 2 + 60, 40);
            label2.Location = new Point(n + 20, 30 + n / 2); label2.Text = "X";
            label3.Location = new Point(n * 2 + 45, 30 + n / 2); label3.Text = "=";
            int[,] firstMatrix = new int[matrixSize, matrixSize];
            int[,] secondMatrix = new int[matrixSize, matrixSize];
            int[,] resultMatrix = new int[matrixSize, matrixSize];
            Label[,] firstMatrixLabels = new Label[showMatrixSize, showMatrixSize];
            Label[,] secondMatrixLabels = new Label[showMatrixSize, showMatrixSize];
            Label[,] resMatrixLabels = new Label[showMatrixSize, showMatrixSize];

            //Генерация матриц
            for (int i = 0; i < matrixSize; i++)
                for (int j = 0; j < matrixSize; j++)
                {
                    firstMatrix[i, j] = rnd.Next(1, 4);
                    if (i < 5 & j < 5)
                    {
                        firstMatrixLabels[i, j] = new Label();
                        firstMatrixLabels[i, j].Text = firstMatrix[i, j].ToString();
                        firstMatrixLabels[i, j].Size = new Size(20, 20);
                        firstMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                        panel1.Controls.Add(firstMatrixLabels[i, j]);
                    }

                    secondMatrix[i, j] = rnd.Next(1, 4);
                    if (i < 5 & j < 5)
                    {
                        secondMatrixLabels[i, j] = new Label();
                        secondMatrixLabels[i, j].Text = secondMatrix[i, j].ToString();
                        secondMatrixLabels[i, j].Size = new Size(20, 20);
                        secondMatrixLabels[i, j].Location = new Point(j * 25, i * 25);
                        panel2.Controls.Add(secondMatrixLabels[i, j]);
                    }

                    if (i < 5 & j < 5)
                    {
                        resMatrixLabels[i, j] = new Label();
                        resMatrixLabels[i, j].Size = new Size(40, 20);
                        resMatrixLabels[i, j].Location = new Point(j * 45, i * 25);
                        panel3.Controls.Add(resMatrixLabels[i, j]);
                    }
                }

            totalTimeLabel.Text = ""; //label для отображения времени
            Stopwatch stopWatch = new Stopwatch(); //таймер (считает не в секундах а в тиках процессора)
            if (radioButton2.Checked) // если мы считаем через таски
            {                               
                Task[] tasks = new Task[matrixSize]; // создание массива тасков (для матрицы 5x5 matrixSize=5)
                for (int t = 0; t < matrixSize; t++) //для каждой строчки в матрице
                {
                    // создание таска, у него есть входной параметр param (туда передаём t которая в цикле выше см. строчку 87)
                    var multiplicacion = new Task((param) => 
                    {
                        int iStatic = (int)param; //параметр у нас это № строки для которой мы будем считать
                        for (int nString = 0; nString < matrixSize; nString++) //цикл для ячеек в строке по которой идём (в результирующей матрице)
                            for (int i = 0; i < matrixSize; i++)
                                resultMatrix[iStatic, nString] += firstMatrix[iStatic, i] * secondMatrix[i, nString];
                        //индексы скопируй по аналогии. resultMatrix - результат                         
                    }, t);
                    tasks[t] = multiplicacion; //пихаем таск в массив
                }
                stopWatch.Start(); // стартуем часики 
                foreach (var item in tasks) // для всех тасков в массиве
                    item.Start(); //стартуем
                Task.WaitAll(tasks); // ждём когда все доработают
                stopWatch.Stop(); // стоп часики 
                totalTimeLabel.Text = "Total ticks: " + stopWatch.ElapsedTicks; // пишем сколько прошло                
            }
            else
            {
                stopWatch.Start();
                for (int i = 0; i < matrixSize; i++)                
                    for (int j = 0; j < matrixSize; j++)
                        for (int x = 0;  x < matrixSize;  x++)                        
                            resultMatrix[i, j] += firstMatrix[i, x] * secondMatrix[x, j];
                stopWatch.Stop();
                totalTimeLabel.Text = "Total ticks: " + stopWatch.ElapsedTicks;
            }

            for (int i = 0; i < showMatrixSize; i++)
                for (int j = 0; j < showMatrixSize; j++)
                    resMatrixLabels[i, j].Text = resultMatrix[i, j].ToString();
        }        
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //Проверка на дурака
            button1.Enabled = (int.TryParse(textBox1.Text, out var x) ? true : false);
        }
    }
}
