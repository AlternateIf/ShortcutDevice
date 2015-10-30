namespace WebSocket.models {
  public class Keystroke {
    public int wParam { get; protected set; }
    public int lParam { get; protected set; }

    public Keystroke(int wParam, int lParam) {
      this.wParam = wParam;
      this.lParam = lParam;
    }
  }
}
