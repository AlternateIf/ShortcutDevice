using System;
using System.Collections.Generic;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLUnitTest {
  [TestClass]
  public class DALTest {
    [TestMethod]
    public void DatabaseCreation() {
      IDatabase database = DALFactory.CreateDatabase();
      Assert.IsTrue(database != null);
    }

    [TestMethod]
    public void PresetDAOCreation() {
      IDatabase database = DALFactory.CreateDatabase();
      IPresetDAO presetDAO = DALFactory.CreatePresetDAO(database);
      Assert.IsTrue(presetDAO != null);
    }

    [TestMethod]
    public void PresetDAOInsertionDeletion() {
      IDatabase database = DALFactory.CreateDatabase();
      IPresetDAO presetDAO = DALFactory.CreatePresetDAO(database);
      presetDAO.DeleteAllEager();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      int i = presetDAO.InsertEager(p);
      p.name = "TestProjektUpdated";
      int j = presetDAO.UpdateEager(p);
      int k = presetDAO.DeleteEager(p);
      Assert.IsTrue(i == 2);
      Assert.IsTrue(j > 0);
      Assert.IsTrue(k == 2);
    }

    [TestMethod]
    public void PresetDAODeleteAll() {
      IDatabase database = DALFactory.CreateDatabase();
      IPresetDAO presetDAO = DALFactory.CreatePresetDAO(database);
      presetDAO.DeleteAllEager();
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button>());
      Preset p2 = new Preset(-1, "TestPreset2", "yellow", new List<Button>());
      int i = presetDAO.InsertEager(p);
      int j = presetDAO.InsertEager(p2);
      int k = presetDAO.DeleteAllEager();
      Assert.IsTrue(i > 0);
      Assert.IsTrue(j > 0);
      Assert.IsTrue(k > 0);
    }

    [TestMethod]
    public void PresetDAOButtonDeletion() {
      IDatabase database = DALFactory.CreateDatabase();
      IPresetDAO presetDAO = DALFactory.CreatePresetDAO(database);
      presetDAO.DeleteAllEager();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      int i = presetDAO.InsertEager(p);
      int k = presetDAO.DeleteButtonEager(button);
      Assert.IsTrue(i == 2);
      Assert.IsTrue(k == 1);
      presetDAO.DeleteAllEager();
    }

    [TestMethod]
    public void PresetDAOFindAll() {
      IDatabase database = DALFactory.CreateDatabase();
      IPresetDAO presetDAO = DALFactory.CreatePresetDAO(database);
      presetDAO.DeleteAllEager();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Button button2 = new Button(-1, "Testbutton2", "no assignment2");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      Preset p2 = new Preset(-1, "TestPreset2", "yellow", new List<Button> { button2 });
      presetDAO.InsertEager(p);
      presetDAO.InsertEager(p2);
      IList<Preset> presets = presetDAO.FindAll();
      Assert.IsTrue(presets.Count == 2);
      Assert.IsTrue(presets[0].buttons.Count == 1);
      Assert.IsTrue(presets[1].buttons.Count == 1);
      presetDAO.DeleteAllEager();
    }

    [TestMethod]
    public void PresetDAOFindByName() {
      IDatabase database = DALFactory.CreateDatabase();
      IPresetDAO presetDAO = DALFactory.CreatePresetDAO(database);
      presetDAO.DeleteAllEager();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Button button2 = new Button(-1, "Testbutton2", "no assignment2");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      Preset p2 = new Preset(-1, "TestPreset2", "yellow", new List<Button> { button2 });
      presetDAO.InsertEager(p);
      presetDAO.InsertEager(p2);
      Preset preset = presetDAO.FindByName("TestPreset1");
      Assert.IsTrue(preset.Equals(p));
      presetDAO.DeleteAllEager();
    }
  }
}
