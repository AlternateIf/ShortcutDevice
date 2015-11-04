using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WebSocket {
  class ConnectionThread {
    public TcpListener threadListener;
    private static int connections = 0;

    public void HandleConnection(object state) {
      int recv = 1;
      byte[] data = new byte[1024];

      TcpClient client = threadListener.AcceptTcpClient();
      Stream ns = client.GetStream();
      try {
        connections++;
        Console.WriteLine("new Client: Currently {0} active connections", connections);
        ASCIIEncoding encoder = new ASCIIEncoding();
        string welcome = "Welcome";
        data = encoder.GetBytes(welcome);
        ns.Write(data, 0, welcome.Length);

        while (encoder.GetString(data, 0, recv) != "Close") {
          data = new byte[1024];
          recv = ns.Read(data, 0, data.Length);
          Console.WriteLine("Client: " + encoder.GetString(data, 0, recv));
        }
      }
      finally {
        ns.Close();
        client.Close();
        connections--;
        Console.WriteLine("Client disconnected: Currently {0} active connections", connections);
      }
    }
  }
  public class Server {
    private TcpListener listener;
    public Server() {
      listener = new TcpListener(IPAddress.Loopback, 9090);
      listener.Start();
      Console.WriteLine("Waiting for clients...");
      while (true) {
        while (!listener.Pending()) {
          Thread.Sleep(1000);
        }
        ConnectionThread newConnection = new ConnectionThread();
        newConnection.threadListener = this.listener;
        ThreadPool.QueueUserWorkItem(new
                   WaitCallback(newConnection.HandleConnection));
      }
    }
    static void Main(string[] args) {
      //----------------Thread Testing--------------------------------------|
      ThreadPool.SetMaxThreads(4, 4);
      Server server = new Server();

      //--------------Emulation Testing-------------------------------------|
      //foreach (Process process in ProcessHandler.GetProcessList()) {
      //  Console.WriteLine(process.Id + " | " + process.ProcessName + " | " + process.MainWindowTitle);
      //}
      //Process firefox = Process.GetProcessById(6844);        // |
      //Shortcut shortcut = new Shortcut(0x10, 0x4E);          // |
      //EmulationHandler.EmulateOnBackground(firefox, "k");      // |
      //EmulationHandlerProcessHandler.EmulateOnForeground(firefox, shortcut); // |
      //----------------------------------------------------------|
    }
  }
}
