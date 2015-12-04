using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketConsole
{
    internal class Program
    {
        private static byte[] result = new byte[1024];
        private static Socket serverSocket;

        private static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Go();
        }

        public async Task Go()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1"); //定义IP

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, 8885)); //绑定地址和端口
            serverSocket.Listen(10); //10个排队请求
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            await ListenClientConnect();
            Console.ReadLine();
        }

        private static async Task ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                await ReceiveMessage(clientSocket);
            }
        }

        private static async Task ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    int receiveNumber = myClientSocket.Receive(result);
                    Console.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(result, 0, receiveNumber));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }
    }
}