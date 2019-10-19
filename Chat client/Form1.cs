using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace Chat_client
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        int old_x = -1, old_y = -1;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
            g = pictureBox1.CreateGraphics();
        }

        TcpClient Client = new TcpClient();
        Socket Socket;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Client.Connect("localhost", 3000);
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения!");
                    return;
                }
                Socket = Client.Client;
                WriteMessage(textBox1.Text + " connected");
                Thread reading = new Thread(ReadMessage);
                reading.Start();
                textBox1.Enabled = button1.Enabled = false;
                textBox2.Enabled = button2.Enabled = listBox1.Enabled = true;
            }
            else MessageBox.Show("Введите имя пользователя!");
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            WriteMessage(textBox1.Text + ": " + textBox2.Text);
            textBox2.Clear();
        }

        private void WriteMessage(string message)
        {
            Socket.Send(Encoding.GetEncoding(1251).GetBytes(message));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            old_x = -1;
            old_y = -1;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (old_x < 0 || old_y < 0)
                {
                    old_x = e.X;
                    old_y = e.Y;
                }
                WriteMessage(string.Format("~{0},{1},{2},{3}", old_x, old_y, e.X, e.Y));
            }
        }

        private void ReadMessage()
        {
            while (true)
            {
                try
                {
                    byte[] read_data = new byte[1024];
                    Socket.Receive(read_data);
                    string msg = Encoding.GetEncoding(1251).GetString(read_data.Where(x => x != 0).ToArray());
                    if (msg[0] == '~')
                        foreach (var m in msg.Split('~').Where(x => x != ""))
                        {
                            string[] str_coords = m.Split(',');
                            int[] int_coords = new int[str_coords.Length];
                            for (int i = 0; i < str_coords.Length; i++)
                                int_coords[i] = Convert.ToInt32(str_coords[i]);
                            g.DrawLine(pen, int_coords[0], int_coords[1], int_coords[2], int_coords[3]);
                            old_x = int_coords[2];
                            old_y = int_coords[3];
                        }
                    else listBox1.BeginInvoke((MethodInvoker)(() => listBox1.Items.Add(msg)));

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    Thread.CurrentThread.Abort();
                    Client.Close();
                }
            }
        }
    }
}
