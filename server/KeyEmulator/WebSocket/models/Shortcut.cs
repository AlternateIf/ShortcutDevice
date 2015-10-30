namespace WebSocket.models {
  public class Shortcut {
    public byte vKCHold { get; protected set; }
    public byte vKC { get; protected set; }

    public Shortcut(byte vKCHold, byte vKC) {
      this.vKCHold = vKCHold;
      this.vKC = vKC;
    }
  }
}
