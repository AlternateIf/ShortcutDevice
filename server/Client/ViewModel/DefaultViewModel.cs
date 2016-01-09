using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using BL;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Client.ViewModel {
  /// <summary>
  /// This class contains properties that a View can data bind to.
  /// <para>
  /// See http://www.galasoft.ch/mvvm
  /// </para>
  /// </summary>
  public class DefaultViewModel : ViewModelBase {
    /// <summary>
    /// Initializes a new instance of the DefaultViewModel class.
    /// </summary>
    private double leftUpperUsage = 0;
    private double rightUpperUsage = 0;
    private double leftLowerUsage = 0;
    private double rightLowerUsage = 0;
    private Process leftUpperProcess = null;
    private Process rightUpperProcess = null;
    private Process leftLowerProcess = null;
    private Process rightLowerProcess = null;
    private BusinessLogicImpl bl = new BusinessLogicImpl();
    private ObservableCollection<Process> processes = null;
    private System.Timers.Timer timeUpperLeft;
    private System.Timers.Timer timeUpperRight;
    private System.Timers.Timer timeLowerLeft;
    private System.Timers.Timer timeLowerRight;
    private Thread luthread = null;
    private Thread ruthread = null;
    private Thread llthread = null;
    private Thread rlthread = null;
    public RelayCommand<Process> LeftUpperProcessSelection { get; set; }
    public RelayCommand<Process> RightUpperProcessSelection { get; set; }
    public RelayCommand<Process> LeftLowerProcessSelection { get; set; }
    public RelayCommand<Process> RightLowerProcessSelection { get; set; }


    public double LeftUpperUsage {
      get { return leftUpperUsage; }
      set {
        leftUpperUsage = value;
        RaisePropertyChanged(() => LeftUpperUsage);
      }
    }

    public double RightUpperUsage {
      get { return rightUpperUsage; }
      set {
        rightUpperUsage = value;
        RaisePropertyChanged(() => RightUpperUsage);
      }
    }

    public double LeftLowerUsage {
      get { return leftLowerUsage; }
      set {
        leftLowerUsage = value;
        RaisePropertyChanged(() => LeftLowerUsage);
      }
    }

    public double RightLowerUsage {
      get { return rightLowerUsage; }
      set {
        rightLowerUsage = value;
        RaisePropertyChanged(() => RightLowerUsage);
      }
    }

    public Process LeftUpperProcess {
      get { return leftUpperProcess; }
      set {
        leftUpperProcess = value;
        RaisePropertyChanged(() => LeftUpperProcess);
      }
    }

    public Process RightUpperProcess {
      get { return rightUpperProcess; }
      set {
        rightUpperProcess = value;
        RaisePropertyChanged(() => RightUpperProcess);
      }
    }

    public Process LeftLowerProcess {
      get { return leftLowerProcess; }
      set {
        leftLowerProcess = value;
        RaisePropertyChanged(() => LeftLowerProcess);
      }
    }

    public Process RightLowerProcess {
      get { return rightLowerProcess; }
      set {
        rightLowerProcess = value;
        RaisePropertyChanged(() => RightLowerProcess);
      }
    }

    public ObservableCollection<Process> Processes {
      get {
        processes = new ObservableCollection<Process>(bl.GetProcessList());
        return processes;
      }
    }


    private void CallbackUpperLeft(object state) {
        Process process = state as Process;
        LeftUpperUsage = bl.getProcessCpuUsage(process);
    }

    private void CallbackUpperRight(object state) {
        Process process = state as Process;
        RightUpperUsage = bl.getProcessCpuUsage(process);
    }

    private void CallbackLowerLeft(object state) {
        Process process = state as Process;
        LeftLowerUsage = bl.getProcessCpuUsage(process);
    }

    private void CallbackLowerRight(object state) {
        Process process = state as Process;
        RightLowerUsage = bl.getProcessCpuUsage(process);
    }

    private void onLeftUpperSelection(Process process) {
      if (timeUpperLeft != null)
        timeUpperLeft.Stop();
      if (luthread != null)
        luthread.Join();
      LeftUpperProcess = process;
      Thread t = new Thread(() => {
        timeUpperLeft = new System.Timers.Timer(200);
        timeUpperLeft.Elapsed += (sender, e) => {
          CallbackUpperLeft(process);
        };
        timeUpperLeft.Start();
      });
      luthread = t;
      t.Start();
    }

    private void onRightUpperSelection(Process process) {
      if (timeUpperRight != null)
        timeUpperRight.Stop();
      if (ruthread != null)
        ruthread.Join();
      RightUpperProcess = process;
      Thread t = new Thread(() => {
        timeUpperRight = new System.Timers.Timer(200);
        timeUpperRight.Elapsed += (sender, e) => {
          CallbackUpperRight(process);
        };
        timeUpperRight.Start();
      });
      ruthread = t;
      t.Start();
    }

    private void onLeftLowerSelection(Process process) {
      if (timeLowerLeft != null)
        timeLowerLeft.Stop();
      if (llthread != null)
        llthread.Join();
      LeftLowerProcess = process;
      Thread t = new Thread(() => {
        timeLowerLeft = new System.Timers.Timer(200);
        timeLowerLeft.Elapsed += (sender, e) => {
          CallbackLowerLeft(process);
        };
        timeLowerLeft.Start();
      });
      llthread = t;
      t.Start();
    }

    private void onRightLowerSelection(Process process) {
      if (timeLowerRight != null)
        timeLowerRight.Stop();
      if (rlthread != null)
        rlthread.Join();
      RightLowerProcess = process;
      Thread t = new Thread(() => {
        timeLowerRight = new System.Timers.Timer(200);
        timeLowerRight.Elapsed += (sender, e) => {
          CallbackLowerRight(process);
        };
        timeLowerRight.Start();
      });
      rlthread = t;
      t.Start();
    }

    public DefaultViewModel() {
      LeftUpperProcessSelection = new RelayCommand<Process>(onLeftUpperSelection);
      RightUpperProcessSelection = new RelayCommand<Process>(onRightUpperSelection);
      LeftLowerProcessSelection = new RelayCommand<Process>(onLeftLowerSelection);
      RightLowerProcessSelection = new RelayCommand<Process>(onRightLowerSelection);
    }
  }
}