using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebSocket.helper;
using WebSocket.models;
namespace WebSocket {
  class EmulationHandler {
    #region DLL Imports
    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", EntryPoint = "PostMessageA")]
    private static extern IntPtr PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
    [DllImport("user32.dll", SetLastError = true)]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    [DllImport("user32.dll")]
    static extern short VkKeyScan(char ch);
    #endregion

    #region static variables
    const int WM_KEYDOWN = 0x100;
    const int WM_KEYUP = 0x0101;
    const int KEYEVENTF_KEYDOWN = 0x0;
    const int KEYEVENTF_KEYUP = 0x2;
    #endregion

    private static void SetForeground(Process assignedProcess) {
      SetForegroundWindow(assignedProcess.MainWindowHandle);
    }

    private static void EmulateKeystrokeOnForeground(Process assignedProcess, short vKC, bool release) {
      if (release) {
        keybd_event((byte)vKC, 0x45, KEYEVENTF_KEYUP, UIntPtr.Zero);
      } else {
        keybd_event((byte)vKC, 0x45, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
      }
    }

    private static void EmulateOnBackground(Process assignedProcess, String msg) {
      short vKC;
      for (int i = 0; i < msg.Length; i++) {
        vKC = VkKeyScan(msg[i]);
        PostMessage(assignedProcess.MainWindowHandle, WM_KEYDOWN, vKC, 0);
      }
    }

    private static void EmulateOnForeground(Process assignedProcess, String msg) {
      short vKC;
      SetForeground(assignedProcess);
      for (int i = 0; i < msg.Length; i++) {
        vKC = VkKeyScan(msg[i]);
        EmulateKeystrokeOnForeground(assignedProcess, vKC, false);
        EmulateKeystrokeOnForeground(assignedProcess, vKC, true);
      }
    }

    private static void Emulate(Shortcut shortcut) {
      Process assignedProcess = ProcessHandler.GetAssignedProcess();
      SetForeground(assignedProcess);
      EmulateKeystrokeOnForeground(assignedProcess, shortcut.vKCHold, false);
      EmulateKeystrokeOnForeground(assignedProcess, shortcut.vKC, false);
      EmulateKeystrokeOnForeground(assignedProcess, shortcut.vKC, true);
      EmulateKeystrokeOnForeground(assignedProcess, shortcut.vKCHold, true);

    }

    public static void Emulate(String msg) {
      Process assignedProcess = ProcessHandler.GetAssignedProcess();
      if (ProcessHandler.GetOnBackground()) {
        EmulateOnBackground(assignedProcess, msg);
      } else {
        EmulateOnForeground(assignedProcess, msg);
      }
    }

  }
}
