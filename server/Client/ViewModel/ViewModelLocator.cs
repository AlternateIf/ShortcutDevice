using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Client.ViewModel {
  /// <summary>
  /// This class contains static references to all the view models in the
  /// application and provides an entry point for the bindings.
  /// </summary>
  public class ViewModelLocator {
    /// <summary>
    /// Initializes a new instance of the ViewModelLocator class.
    /// </summary>
    public ViewModelLocator() {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      ////if (ViewModelBase.IsInDesignModeStatic)
      ////{
      ////    // Create design time view services and models
      ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
      ////}
      ////else
      ////{
      ////    // Create run time view services and models
      ////    SimpleIoc.Default.Register<IDataService, DataService>();
      ////}

      SimpleIoc.Default.Register<MainViewModel>();
      SimpleIoc.Default.Register<DefaultViewModel>();
      SimpleIoc.Default.Register<PresetViewModel>();
    }

    public MainViewModel Main {
      get {
        return ServiceLocator.Current.GetInstance<MainViewModel>();
      }
    }

    public DefaultViewModel Default {
      get {
        return ServiceLocator.Current.GetInstance<DefaultViewModel>();
      }
    }

    public PresetViewModel Preset {
      get {
        return ServiceLocator.Current.GetInstance<PresetViewModel>();
      }
    }

    public static void Cleanup() {
      // TODO Clear the ViewModels
    }
  }
}