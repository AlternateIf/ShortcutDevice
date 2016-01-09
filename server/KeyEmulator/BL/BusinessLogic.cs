using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL {
  public interface BusinessLogic {
    IList<Preset> GetPresets();
    Preset GetPresetByName(string name);
    bool DeletePresetEager(Preset preset);
    bool UpdatePresetEager(Preset preset);
    bool InsertPresetEager(Preset preset);
    IList<Process> GetProcessList();
    double getProcessCpuUsage(Process process);
  }
}
