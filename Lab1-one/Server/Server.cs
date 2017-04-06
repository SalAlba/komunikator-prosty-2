using System;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class Server
    {
        // Fields ...
        private const string IP_ADRESS = "127.0.0.1";
        private const int PORT = 2222;
        private const int DATAGRAM_SIZE = 10;
        private static int num = 0;
        private static TcpListener tcpListener;
        private static Socket socket;

        // main ...
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("1) Hi I'm server :)");
            Console.WriteLine("2) Sever start...");
            Console.WriteLine("--------------------------------------");

            startServer();
            reciveData();
         
            Console.ReadLine();
            stopServer();
        }

        
        ///  methods ....
        
        // START
        private static void startServer() {
            tcpListener = new TcpListener(IPAddress.Parse(IP_ADRESS), PORT);
            tcpListener.Start(); // START 
            socket = tcpListener.AcceptSocket();
        }

        // STOP 
        private static void stopServer() { tcpListener.Stop();  }


        private static void reciveData() {
            int flag = 1;

            while (flag == 1)
            {

                // recive data
                Byte[] reciveData = new Byte[DATAGRAM_SIZE];
                int error = socket.Receive(reciveData, reciveData.Length, 0);
                string msg = null;
                msg = System.Text.Encoding.ASCII.GetString(reciveData);

                if (msg.Length > 0)
                {
                    Console.WriteLine("{0} Client msg ) {1} ;", num++, msg);

                    if (msg.Contains("quit"))
                    {
                        flag = 0;
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Press Enter to finish !!");
                    }

                }
            }
        }



    }
}
