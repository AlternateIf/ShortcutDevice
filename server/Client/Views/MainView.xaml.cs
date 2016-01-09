using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client.Views {
  /// <summary>
  /// Description for MainView.
  /// </summary>
  public partial class MainView : UserControl {
    /// <summary>
    /// Initializes a new instance of the MainView class.
    /// </summary>
    public MainView() {
      InitializeComponent();
    }

    private Brush prevBrush = null;

    private void ProcessButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) {
      prevBrush = (sender as Button).Background;
      (sender as Button).Background = Brushes.LightSteelBlue;
    }

    private void ProcessButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e) {
      (sender as Button).Background = prevBrush;
    }
  }
}