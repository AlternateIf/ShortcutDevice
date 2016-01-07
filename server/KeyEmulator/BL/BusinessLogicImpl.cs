using System.Collections.Generic;
using DAL;

namespace BL {
  public class BusinessLogicImpl : BusinessLogic {
    IDatabase database = null;
    IPresetDAO presetDAO = null;
    IList<Preset> presets = null;
    IList<Button> buttons = new List<Button>();
    public BusinessLogicImpl() {
      database = DALFactory.CreateDatabase();
      presetDAO = DALFactory.CreatePresetDAO(database);
      presets = presetDAO.FindAll();
      foreach (var preset in presets) {
        foreach (var button in preset.buttons) {
          if (!preset.buttons.Contains(button))
            buttons.Add(button);
        }
      }
    }
    public bool DeletePresetEager(Preset preset) {
      if (presets.Contains(preset) && preset.name.Length <= 30 && preset.color.Length <= 30) {
        presets.Remove(preset);
        return presetDAO.DeleteEager(preset) != 0;
      } else return false;
    }

    public Preset GetPresetByName(string name) {
      Preset returnPreset = null;
      foreach (var preset in presets) {
        if (preset.name == name) {
          returnPreset = preset;
          break;
        }
      }
      return returnPreset;
    }

    public IList<Preset> GetPresets() {
      return presets;
    }

    public bool UpdatePresetEager(Preset preset) {
      if (!presets.Contains(preset) || preset.name.Length > 30 || preset.color.Length > 30)
        return false;
      else {
        foreach (var button in preset.buttons) {
          if (button.name.Length > 50 || button.assignment.Length > 50)
            return false;
        }
      }
      int i = 0;
      foreach (var presetlooper in presets) {
        if (presetlooper.id == preset.id) {
          presets.Remove(presetlooper);
          presets.Add(preset);
          return presetDAO.UpdateEager(preset) != 0;
        }
        i++;
      }
      return false;
    }

    public bool InsertPresetEager(Preset preset) {
      if (presets.Contains(preset) || preset.name.Length > 30 || preset.color.Length > 30)
        return false;
      else {
        foreach (var button in preset.buttons) {
          if (button.name.Length > 50 || button.assignment.Length > 50)
            return false;
        }
        presets.Add(preset);
        return presetDAO.InsertEager(preset) != 0;
      }
    }
  }
}
