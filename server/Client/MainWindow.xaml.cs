using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace Client {
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      #region running server

      #region todo
      //set PATH
      #endregion

      #region server variables
      const string PATH = "";
      Process server = new Process();
      #endregion

      server.StartInfo.FileName = PATH;
      #endregion
      if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;
      InitializeComponent();
    }
  }
}
