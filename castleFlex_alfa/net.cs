using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace castleFlex_alfa
{
    class net
    {
        public static TwoGameWin twoGameWin = new TwoGameWin();
        public static void sendData(string info,string ip, int port)
        {
            UdpClient sender = new UdpClient();
            byte[] data = Encoding.Unicode.GetBytes(info);
            sender.Send(data, data.Length, ip, port);
            sender.Close();
        }
        public static string receiveData(int port)
        {
            UdpClient receiver = new UdpClient(port);
            IPEndPoint ip = null;
            byte[] data = receiver.Receive(ref ip);
            string info = Encoding.Unicode.GetString(data);
            receiver.Close();
            return info;
        }
        public static void nameChanger(string ip, int port, int recport)
        {
            UdpClient namer;
            //GlobalVariables global = new GlobalVariables();
            
            byte[] name;

            void listenName()
            {
                namer = new UdpClient(recport);
                IPEndPoint ipend = null;
                name = namer.Receive(ref ipend);
                twoGameWin.p2name.Content = Encoding.Unicode.GetString(name);
                namer.Close();
            }
            //Thread recName = new Thread(new ThreadStart(listenName));
            //recName.Start();

            namer = new UdpClient();
            name = Encoding.Unicode.GetBytes(GlobalVariables.username);
            namer.Send(name, name.Length, ip, port);
            namer.Close();
        }
    }
}
