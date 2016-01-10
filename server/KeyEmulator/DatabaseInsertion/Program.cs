using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL;

namespace DatabaseInsertion {
  class Program {
    static void Main(string[] args) {
      BusinessLogicImpl bl = new BusinessLogicImpl();
      Button button1 = new Button(-1, "Button 1", "message 1");
      Button button2 = new Button(-1, "Button 2", "message 2");
      Button button3 = new Button(-1, "Button 3", "message 3");
      Button button4 = new Button(-1, "Button 4", "message 4");
      Button button5 = new Button(-1, "Button 5", "message 5");
      Button button6 = new Button(-1, "Button 6", "message 6");
      Preset preset = new Preset(-1, "Test-Preset", "green", new List<Button> ( 
        new Button[] { button1, button2, button3, button4, button5, button6}));
      bl.InsertPresetEager(preset);
    }
  }
}
