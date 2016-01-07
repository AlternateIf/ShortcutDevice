using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL.Specified {
  public class PresetDAO : IPresetDAO {
    private string SQL_FINDBYNAME = "SELECT * FROM PresetWithButtons WHERE presetName=@presetName";
    private string SQL_FINDALL = "SELECT * FROM presetwithbuttons";
    private string SQL_DELETE = "DELETE FROM Preset WHERE name=@name";
    private string SQL_DELETEBUTTON = "DELETE FROM BUTTON WHERE id=@id";
    private string SQL_DELETEBUTTONMN = "DELETE FROM Preset_has_Button WHERE Button_id=@buttonId";
    private string SQL_DELETEPRESETMN = "DELETE FROM Preset_has_Button WHERE Preset_id=@presetId";
    private string SQL_DELETEMNALL = "DELETE FROM Preset_has_Button";
    private string SQL_DELETEALL = "DELETE FROM Preset";
    private string SQL_DELETEALLBUTTON = "DELETE FROM BUTTON";
    private string SQL_UPDATEPRESET = "UPDATE Preset SET name=@name,color=@color WHERE id=@id";
    private string SQL_UPDATEBUTTON = "UPDATE Button SET assignment=@assignment, name=@name WHERE id=@id";
    private string SQL_INSERTPRESET = "INSERT INTO Preset (name, color) VALUES (@name, @color)";
    private string SQL_INSERTMN = "INSERT INTO Preset_has_Button (Preset_id, Button_id) VALUES (@pid, @id)";
    private string SQL_INSERTBUTTON = "INSERT INTO Button (assignment, name) VALUES (@assignment, @name)";
    private string SQL_MAXIDPRESET = "SELECT MAX(id) as id FROM Preset";
    private string SQL_MAXIDBUTTON = "SELECT MAX(id) as id FROM BUTTON";
    private IDatabase database { get; set; }

    public PresetDAO(IDatabase database) {
      this.database = database;
    }

    private MySqlCommand CreateFindByNameCommand(string name) {
      MySqlCommand command = database.CreateCommand(SQL_FINDBYNAME);
      database.DefineParameter(command, "@presetName", MySqlDbType.String, name);
      return command;
    }

    private MySqlCommand CreateFindAllCommand() {
      MySqlCommand command = database.CreateCommand(SQL_FINDALL);
      return command;
    }

    private MySqlCommand CreateDeleteCommand(Preset preset) {
      MySqlCommand command = database.CreateCommand(SQL_DELETE);
      database.DefineParameter(command, "@name", MySqlDbType.String, preset.name);
      return command;
    }

    private MySqlCommand CreateDeletePresetMNCommand(Preset preset) {
      MySqlCommand command = database.CreateCommand(SQL_DELETEPRESETMN);
      database.DefineParameter(command, "@presetId", MySqlDbType.Int32, preset.id);
      return command;
    }


    private MySqlCommand CreateDeleteButtonCommand(Button button) {
      MySqlCommand command = database.CreateCommand(SQL_DELETEBUTTON);
      database.DefineParameter(command, "@id", MySqlDbType.Int32, button.id);
      return command;
    }

    private MySqlCommand CreateDeleteButtonMNCommand(Button button) {
      MySqlCommand command = database.CreateCommand(SQL_DELETEBUTTONMN);
      database.DefineParameter(command, "@buttonId", MySqlDbType.Int32, button.id);
      return command;
    }

    private MySqlCommand CreateDeleteAllCommand() {
      MySqlCommand command = database.CreateCommand(SQL_DELETEALL);
      return command;
    }

    private MySqlCommand CreateDeleteMNAllCommand() {
      MySqlCommand command = database.CreateCommand(SQL_DELETEMNALL);
      return command;
    }

    private MySqlCommand CreateDeleteAllButtonCommand() {
      MySqlCommand command = database.CreateCommand(SQL_DELETEALLBUTTON);
      return command;
    }

    private MySqlCommand CreateUpdateCommand(Preset preset) {
      MySqlCommand command = database.CreateCommand(SQL_UPDATEPRESET);
      database.DefineParameter(command, "@id", MySqlDbType.String, preset.id);
      database.DefineParameter(command, "@name", MySqlDbType.String, preset.name);
      database.DefineParameter(command, "@color", MySqlDbType.String, preset.color);
      return command;
    }

    private MySqlCommand CreateUpdateButtonCommand(Button button) {
      MySqlCommand command = database.CreateCommand(SQL_UPDATEBUTTON);
      database.DefineParameter(command, "@name", MySqlDbType.String, button.name);
      database.DefineParameter(command, "@assignment", MySqlDbType.String, button.assignment);
      database.DefineParameter(command, "@id", MySqlDbType.Int32, button.id);
      return command;
    }

    private MySqlCommand CreateInsertCommand(Preset preset) {
      MySqlCommand command = database.CreateCommand(SQL_INSERTPRESET);
      database.DefineParameter(command, "@name", MySqlDbType.String, preset.name);
      database.DefineParameter(command, "@color", MySqlDbType.String, preset.color);
      return command;
    }

    private MySqlCommand CreateInsertMNCommand(int id, int pid) {
      MySqlCommand command = database.CreateCommand(SQL_INSERTMN);
      database.DefineParameter(command, "@pid", MySqlDbType.Int32, pid);
      database.DefineParameter(command, "@id", MySqlDbType.Int32, id);
      return command;
    }

    private MySqlCommand CreateInsertButtonCommand(Button button) {
      MySqlCommand command = database.CreateCommand(SQL_INSERTBUTTON);
      database.DefineParameter(command, "@name", MySqlDbType.String, button.name);
      database.DefineParameter(command, "@assignment", MySqlDbType.String, button.assignment);
      return command;
    }

    private MySqlCommand CreateMaxIdPresetCommand() {
      MySqlCommand command = database.CreateCommand(SQL_MAXIDPRESET);
      return command;
    }

    private MySqlCommand CreateMaxIdButtonCommand() {
      MySqlCommand command = database.CreateCommand(SQL_MAXIDBUTTON);
      return command;
    }

    public int DeleteAllEager() {
      using (MySqlCommand command = CreateDeleteMNAllCommand()) {
        database.ExecuteNonQuery(command);
        using (MySqlCommand command2 = CreateDeleteAllButtonCommand()) {
          using (MySqlCommand command3 = CreateDeleteAllCommand()) {
            return database.ExecuteNonQuery(command2) + database.ExecuteNonQuery(command3);
          }
        }
      }
    }

    public int DeleteEager(Preset preset) {
      int i = 0;
      using (MySqlCommand command = CreateDeletePresetMNCommand(preset)) {
        database.ExecuteNonQuery(command);
      }
      foreach (var button in preset.buttons) {
        using (MySqlCommand command = CreateDeleteButtonCommand(button)) {
          i += database.ExecuteNonQuery(command);
        }
      }
      using (MySqlCommand command = CreateDeleteCommand(preset)) {
        return i + database.ExecuteNonQuery(command);
      }
    }

    public IList<Preset> FindAll() {
      using (MySqlCommand command = CreateFindAllCommand()) {
        using (IDataReader reader = database.ExecuteReader(command)) {
          IList<Preset> presets = new List<Preset>();
          IList<Button> buttons = new List<Button>();
          int oldpreset = -1;
          int preset = -2;
          Preset currentPreset = null;
          while (reader != null && reader.IsClosed == false && reader.Read()) {
            oldpreset = preset;
            preset = (int)reader["presetId"];
            if (oldpreset != preset) {
              if (currentPreset != null)
                presets.Add(currentPreset);
              buttons = new List<Button>();
              buttons.Add(new Button((int)reader["buttonId"], (string)reader["buttonName"], (string)reader["buttonAssignment"]));
              currentPreset = new Preset((int)reader["presetId"], (string)reader["presetName"], (string)reader["presetColor"], buttons);
            } else {
              buttons.Add(new Button((int)reader["buttonId"], (string)reader["buttonName"], (string)reader["buttonAssignment"]));
              currentPreset.buttons = buttons;
            }
          }
          if (currentPreset != null)
            presets.Add(currentPreset);
          return presets;
        }
      }
    }

    public Preset FindByName(string name) {
      using (MySqlCommand command = CreateFindByNameCommand(name)) {
        using (IDataReader reader = database.ExecuteReader(command)) {
          IList<Button> buttons = new List<Button>();
          Preset currentPreset = null;
          while (reader != null && reader.IsClosed == false && reader.Read()) {
            buttons.Add(new Button((int)reader["buttonId"], (string)reader["buttonName"], (string)reader["buttonAssignment"]));
            currentPreset = new Preset((int)reader["presetId"], (string)reader["presetName"], (string)reader["presetColor"], buttons);
            while (reader != null && reader.IsClosed == false && reader.Read()) {
              buttons.Add(new Button((int)reader["buttonId"], (string)reader["buttonName"], (string)reader["buttonAssignment"]));
            }
          }
          currentPreset.buttons = buttons;
          return currentPreset;
        }
      }
    }

    public int UpdateEager(Preset preset) {
      int i = 0;
      foreach (var button in preset.buttons) {
        using (MySqlCommand command = CreateUpdateButtonCommand(button)) {
          i += database.ExecuteNonQuery(command);
        }
      }
      using (MySqlCommand command = CreateUpdateCommand(preset)) {
        return i + database.ExecuteNonQuery(command);
      }
    }

    public int InsertEager(Preset preset) {
      int i = 0;
      int j = 0;
      int[] buttonIdArr = new int[preset.buttons.Count + 1];
      int pos = 0;
      foreach (var button in preset.buttons) {
        using (MySqlCommand command = CreateInsertButtonCommand(button)) {
          i += database.ExecuteNonQuery(command);
          button.id = (int)command.LastInsertedId;
          buttonIdArr[pos++] = button.id;
        }
      }
      using (MySqlCommand command = CreateInsertCommand(preset)) {
        j = database.ExecuteNonQuery(command);
        preset.id = (int)command.LastInsertedId;
      }
      foreach (var id in buttonIdArr) {
        using (MySqlCommand command = CreateInsertMNCommand(id, preset.id)) {
          database.ExecuteNonQuery(command);
        }
      }
      return i + j;
    }

    public int DeleteButtonEager(Button button) {
      using (MySqlCommand command1 = CreateDeleteButtonMNCommand(button)) {
        database.ExecuteNonQuery(command1);
        using (MySqlCommand command = CreateDeleteButtonCommand(button)) {
          return database.ExecuteNonQuery(command);
        }
      }
    }
  }
}
