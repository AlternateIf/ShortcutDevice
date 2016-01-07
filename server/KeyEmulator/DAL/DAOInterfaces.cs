using System.Collections.Generic;

namespace DAL {
  public interface IPresetDAO {
    Preset FindByName(string name);
    IList<Preset> FindAll();
    int DeleteEager(Preset preset);
    int DeleteAllEager();
    int UpdateEager(Preset preset);
    int InsertEager(Preset preset);
    int DeleteButtonEager(Button button);
  }
}
