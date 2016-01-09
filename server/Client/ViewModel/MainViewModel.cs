using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Client.ViewModel {
  /// <summary>
  /// This class contains properties that the main View can data bind to.
  /// <para>
  /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
  /// </para>
  /// <para>
  /// You can also use Blend to data bind with the tool's support.
  /// </para>
  /// <para>
  /// See http://www.galasoft.ch/mvvm
  /// </para>
  /// </summary>
  public class MainViewModel : ViewModelBase {
    /// <summary>
    /// Initializes a new instance of the MainViewModel class.
    /// </summary>
    private Visibility visibilityDefault = Visibility.Visible;
    private Visibility visibilityPreset = Visibility.Collapsed;
    private Color processBorder = Color.FromRgb(51, 153, 255);
    private Color presetBorder = Color.FromRgb(105, 105, 105);
    private string borderChange = "";
    public RelayCommand OnProcessClickCommand { get; set; }
    public RelayCommand OnPresetClickCommand { get; set; }

    public Color ProcessBorder {
      get { return processBorder; }
      set {
        this.processBorder = value;
        RaisePropertyChanged(() => ProcessBorder);
      }
    }

    public Color PresetBorder {
      get { return presetBorder; } 
      set {
        this.presetBorder = value;
        RaisePropertyChanged(() => PresetBorder);
      }
    }

    public Visibility VisibilityDefault {
      get {
        return visibilityDefault;
      }
      set {
        visibilityDefault = value;
        RaisePropertyChanged(() => VisibilityDefault);
      }
    }

    public Visibility VisibilityPreset {
      get {
        return visibilityPreset;
      }
      set {
        visibilityPreset = value;
        RaisePropertyChanged(() => VisibilityPreset);
      }
    }

    public string BorderChange {
      get { return borderChange; }
      set {
        if (!(this.borderChange.Equals(value))) {
          this.borderChange = value;
          ProcessBorder = Color.FromRgb(105, 105, 105);
          PresetBorder = Color.FromRgb(105, 105, 105);
          if (borderChange.Equals("Process"))
            ProcessBorder = Color.FromRgb(51,153, 255);
          else if (borderChange.Equals("Preset"))
            PresetBorder = Color.FromRgb(51, 153, 255); ;
        }
      }
    }

    private void ProcessClick() {
      BorderChange = "Process";
      VisibilityDefault = Visibility.Visible;
      VisibilityPreset = Visibility.Collapsed;
    }

    private void PresetClick() {
      BorderChange = "Preset";
      VisibilityDefault = Visibility.Collapsed;
      VisibilityPreset = Visibility.Visible;
    }

    public MainViewModel() {
      OnProcessClickCommand = new RelayCommand(ProcessClick);
      OnPresetClickCommand = new RelayCommand(PresetClick);
    }
  }
}