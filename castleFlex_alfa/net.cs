using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace castleFlex_alfa
{
    class net
    {
        class Client
        {
            public void Connection(string ip,int port)
            {
                TcpClient Connection = new TcpClient(ip, port);
            }
        }
        class Server
        {

        }
    }
}
