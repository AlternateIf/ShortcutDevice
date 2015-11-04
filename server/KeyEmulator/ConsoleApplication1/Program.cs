using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConnectionClient {
  class Program {
    static void Main(string[] args) {
      TcpClient client = new TcpClient();
      Console.WriteLine("Client: Connecting.");
      client.Connect(IPAddress.Loopback, 9090);
      Stream stream = client.GetStream();
      String msg = "Close";
      int recv = 0;
      ASCIIEncoding encoder = new ASCIIEncoding();
      byte[] encodedMsg = new byte[1024];
      recv = stream.Read(encodedMsg, 0, encodedMsg.Length);
      Console.WriteLine("Server: " + encoder.GetString(encodedMsg, 0, recv));
      encodedMsg = encoder.GetBytes(msg);
      //close connection serverside
      stream.Write(encodedMsg, 0, encodedMsg.Length);
      stream.Close();
      client.Close();
    }
  }
}
