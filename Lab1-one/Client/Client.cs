using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Client
    {
        // Fields ...
        private const string IP_ADRESS = "127.0.0.1";
        private const int PORT = 2222;
        private static Socket socket;

        // main ...
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("1) Hi I'm client :)");
            Console.WriteLine("2) Conect to server");
            Console.WriteLine("--------------------------------------");
            connect();

            send("FIRST MSG FROM CLIENT CHECKING :))");

            while (true) {
                string msg = Console.ReadLine();
                send(msg);
                if (msg.Contains("quit")) break;
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Press Enter to finish !!");


            Console.ReadLine();
        }

        // Methods ...
        private static void connect() {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IP_ADRESS), PORT);
            socket.Connect(ipEndPoint);
        }

        private static void send(string msg){
            Byte[] byteData = Encoding.ASCII.GetBytes(msg.ToCharArray());
            socket.Send(byteData, byteData.Length, 0);
        }

    }
}
