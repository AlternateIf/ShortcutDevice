using System;
using System.Collections.Generic;
using BL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLUnitTest {
  [TestClass]
  public class BLTest {

    [TestMethod]
    public void BusinessLogicCreation() {
      BusinessLogic bl = new BusinessLogicImpl();
      Assert.IsTrue(bl != null);
    }

    [TestMethod]
    public void InsertionDeletionTest() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == true);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == true);
    }

    [TestMethod]
    public void InsertionTestNotValid1() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1, 
        "TestPreset1dddddccccccccccccccccccccccccccvewvewvewvwccccccscaaaaaaasfhtrjzstnymsg,ts,tzs," +
        "sztdfbdbddsdvdsd sd sd sdveqwqqvwebwbwsfefewvwevwvewveevffffffffffffffffffffffffffffffffffff", 
        "green", new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == false);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == false);
    }

    [TestMethod]
    public void InsertionTestNotValid2() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1,
        "TestPreset1",
        "greendccccccccccccccccccccccccccccccwqdqwdqwdqwccscaaaaaaasfhtrjzstnymsg,ts,tzs," +
        "sztdfbdbddsdvdsd sd sd sdveqwqqvwebwbwsfevqevdvawfffffffffffffffffffffffffffffffffffff", 
        new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == false);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == false);
    }

    [TestMethod]
    public void InsertionTestNotValid3() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, 
        "Testbuttongreendccccccccccccccccccccwqwqdqwdwqdwqdccccccccccccscaaaaaaasfhtrjzstnymsg,ts,tzs," +
        "sztdfbdbddsdvdsd sd sd sdveqwqqvwebwbwqwdqwdsfefffffffffffffffffffffffffffffffffffff", "no assignment");
      Preset p = new Preset(-1,
        "TestPreset1",
        "green",
        new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == false);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == false);
    }

    [TestMethod]
    public void InsertionTestNotValid4() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton",
        "no assignmentgreendccccccccccccccccccccccccccccccccscaaaaaaasfdqwdhtrjzstnymsg,ts,tzs," +
        "sztdfbdbddsdvdsd sd sd sdveqwqqvwebwbwsfeffffffffffffffffwqdqwdqwdfffffffffffffffffffff");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == false);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == false);
    }

    [TestMethod]
    public void UpdateTest() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton","no assignment");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == true);
      p.name = "TestPreset12";
      b = bl.UpdatePresetEager(p);
      Assert.IsTrue(b == true);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == true);
    }

    [TestMethod]
    public void UpdateTest2() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == true);
      p.color = "Yellow";
      b = bl.UpdatePresetEager(p);
      Assert.IsTrue(b == true);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == true);
    }

    [TestMethod]
    public void UpdateTest3() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == true);
      p.buttons[0].name = "TestButton12";
      b = bl.UpdatePresetEager(p);
      Assert.IsTrue(b == true);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == true);
    }

    [TestMethod]
    public void UpdateTest4() {
      BusinessLogic bl = new BusinessLogicImpl();
      Button button = new Button(-1, "Testbutton", "no assignment");
      Preset p = new Preset(-1, "TestPreset1", "green", new List<Button> { button });
      bool b = bl.InsertPresetEager(p);
      Assert.IsTrue(b == true);
      p.buttons[0].assignment = "TestAssignment";
      b = bl.UpdatePresetEager(p);
      Assert.IsTrue(b == true);
      b = bl.DeletePresetEager(p);
      Assert.IsTrue(b == true);
    }
  }
}
