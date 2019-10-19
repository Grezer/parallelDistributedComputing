using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Chat_server
{
    public class Connection
    {
        TcpListener Listener;
        Socket Client;
        static List<Connection> allСonnections = new List<Connection>();

        public Connection(TcpListener newListener)
        {
            try
            {
                Listener = newListener;
                Client = Listener.AcceptSocket();
                allСonnections.Add(this);
            }
            catch
            {
                Client.Close();
                Thread.CurrentThread.Abort();
            }
        }

        public void StartRead()
        {
            try
            {
                while (true)
                {
                    string data = ReadMessage();
                    WriteMessage(data);
                }
            }
            catch
            {
                Client.Close();
                Thread.CurrentThread.Abort();
            }
        }

        private string ReadMessage()
        {
            byte[] readData = new byte[1024];
            int bytes_count = Client.Receive(readData);
            string message = Encoding.GetEncoding(1251).GetString(readData.Where(x => x != 0).ToArray());
            Console.WriteLine(message);
            return message;
        }

        private void WriteMessage(string message)
        {
            foreach (Connection item in allСonnections)
            {
                item.Client.Send(Encoding.GetEncoding(1251).GetBytes(message));
            }
        }
    }
}
