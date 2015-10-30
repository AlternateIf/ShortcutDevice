using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebSocket.models;

namespace WebSocket {
  class ProcessHandler {
    #region DLL Imports
    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", EntryPoint = "PostMessageA")]
    private static extern IntPtr PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
    #endregion
    #region static variables
    const int WM_KEYDOWN = 0x100;
    const int WM_SYSKEYDOWN = 0x0104;
    const int WM_KEYUP = 0x0101;
    #endregion

    public static void SetForeground(Process assignedProcess) {
      SetForegroundWindow(assignedProcess.MainWindowHandle);
    }

    public static void EmulateKeyStrokeOnBackground(Process assignedProcess, Keystroke key) {
      PostMessage(assignedProcess.MainWindowHandle, WM_KEYDOWN, key.wParam, key.lParam);
      PostMessage(assignedProcess.MainWindowHandle, WM_KEYUP, key.wParam, key.lParam);
    }

    private static bool IsActive(Process assignedProcess) {
      Process activatedWindow = Process.GetCurrentProcess();
      return assignedProcess.Id == activatedWindow.Id;
    }

    public static void EmulateKeyStrokeOnForeground(Process assignedProcess, Keystroke key) {
      if (!IsActive(assignedProcess)) {
        SetForeground(assignedProcess);
      }
      //emulate
    }

    public static void EmulateMessageOnForeground(Process assignedProcess, Message msg) {
      if (!IsActive(assignedProcess)) {
        SetForeground(assignedProcess);
      }
      //emulate
    }
  }
}
