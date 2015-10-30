namespace WebSocket.models {
  public class Message {
    public string msg { get; protected set; }
    public Message(string msg) {
      this.msg = msg;
    }
  }
}
