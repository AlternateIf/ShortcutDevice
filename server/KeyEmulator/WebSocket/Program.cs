using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebSocket
{
    class Server {
        #region todo
        //Create threads for multiple connections
        //think about running the server from the GUI
        //if so use Async Accept for GUI
        #endregion
        static void Main(string[] args) {
            #region setting up server
            #region explanation
            //creating a TCPListener to wait for a connection. It then accepts
            //the connection and returns a TCPClient Object. Due to the Vision-
            //Server and the websocket server being on the same machine for
            //this program i am going to use the Localhost on Port 80.
            #endregion
            #region server variables
            IPAddress HOST_ADDRESS = IPAddress.Loopback;
            int PORT = 80;
            #endregion
            TcpListener server = new TcpListener(HOST_ADDRESS, PORT);

            server.Start();
            Console.WriteLine("Server is listening to {0} on port {1}.", HOST_ADDRESS, PORT);
            TcpClient client = server.AcceptTcpClient();
            #endregion
        }
    }
}
