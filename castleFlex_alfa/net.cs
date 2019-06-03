using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace castleFlex_alfa
{
    class net
    {
        class Client
        {
            static int localPort; // порт приема сообщений
            static int remotePort; // порт для отправки сообщений
            static Socket listeningSocket;

            static void UDPclient(string lp, string rp)
            {
                localPort = Int32.Parse(lp);
                remotePort = Int32.Parse(rp);
                
                try
                {
                    listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    Task listeningTask = new Task(Listen);
                    listeningTask.Start();

                    // отправка сообщений на разные порты
                    while (true)
                    {
                        string message = Console.ReadLine();

                        byte[] data = Encoding.Unicode.GetBytes(message);
                        EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), remotePort);
                        listeningSocket.SendTo(data, remotePoint);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Close();
                }
            }

            // поток для приема подключений
            private static void Listen()
            {
                try
                {
                    //Прослушиваем по адресу
                    IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), localPort);
                    listeningSocket.Bind(localIP);

                    while (true)
                    {
                        // получаем сообщение
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0; // количество полученных байтов
                        byte[] data = new byte[256]; // буфер для получаемых данных

                        //адрес, с которого пришли данные
                        EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);

                        do
                        {
                            bytes = listeningSocket.ReceiveFrom(data, ref remoteIp);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (listeningSocket.Available > 0);
                        // получаем данные о подключении
                        IPEndPoint remoteFullIp = remoteIp as IPEndPoint;

                        // выводим сообщение
                        Console.WriteLine("{0}:{1} - {2}", remoteFullIp.Address.ToString(),
                                                        remoteFullIp.Port, builder.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Close();
                }
            }
            // закрытие сокета
            private static void Close()
            {
                if (listeningSocket != null)
                {
                    listeningSocket.Shutdown(SocketShutdown.Both);
                    listeningSocket.Close();
                    listeningSocket = null;
                }
            }
        }
        class Server
        {

        }
    }
}
