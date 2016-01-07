using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL {
  public class Preset : Object {
    private const int MAX_BUTTONS = 6;
    public string name { get; set; }
    public string color { get; set; }
    public int id { get; set; }
    public IList<Button> buttons { get; set; }

    public Preset(int id, string name, string color, IList<Button> buttons) {
      this.id = id;
      this.name = name;
      this.color = color;
      if (buttons == null)
        this.buttons = new List<Button>();
      else
        this.buttons = buttons;
    }

    public override bool Equals(object obj) {
      Preset preset = obj as Preset;
      return preset.id == this.id && preset.name == this.name &&
        preset.color == this.color && preset.buttons.SequenceEqual(this.buttons);
    }
    public override int GetHashCode() {
      return base.GetHashCode();
    }

    public bool AddButton(Button button) {
      if (this.buttons.Count < MAX_BUTTONS && !this.buttons.Contains(button)) {
        this.buttons.Add(button);
        return this.buttons.Count <= MAX_BUTTONS;
      } else return false;
    }
  }
  public class Button : Object {
    public string name { get; set; }
    public int id { get; set; }
    public string assignment { get; set; }

    public Button(int id, string name, string assignment) {
      this.id = id;
      this.name = name;
      this.assignment = assignment;
    }

    public override bool Equals(object obj) {
      Button button = obj as Button;
      return this.id == button.id && this.name == button.name &&
        this.assignment == button.assignment;
    }

    public override int GetHashCode() {
      return base.GetHashCode();
    }
  }
}
