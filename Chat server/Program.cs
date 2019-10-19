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
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 3000);
            listener.Start();
            while (true)
            {
                Console.WriteLine("listen 127.0.0.1:3000");
                Connection new_connection = new Connection(listener);
                Thread thread = new Thread(new_connection.StartRead);
                thread.Start();
            }
        }
    }
}
