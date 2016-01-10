using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BL;
using DAL;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Client.ViewModel {
  /// <summary>
  /// This class contains properties that a View can data bind to.
  /// <para>
  /// See http://www.galasoft.ch/mvvm
  /// </para>
  /// </summary>
  public class PresetViewModel : ViewModelBase {
    /// <summary>
    /// Initializes a new instance of the PresetViewModel class.
    /// </summary>
    private BusinessLogicImpl bl = new BusinessLogicImpl();
    private ObservableCollection<Preset> presets = null;
    private Preset add = new Preset(-1, "+", "", new List<Button>());
    private Preset selectedPreset = null;
    private string buttonText = "Hinzufügen";
    private string errorText = "";
    private Visibility errorVisibility = Visibility.Collapsed;
    private string button1Text = "Button-name";
    private string button2Text = "Button-name";
    private string button3Text = "Button-name";
    private string button4Text = "Button-name";
    private string button5Text = "Button-name";
    private string button6Text = "Button-name";
    private string selectedEmulation1 = "Shortcut";
    private string selectedEmulation2 = "Shortcut";
    private string selectedEmulation3 = "Shortcut";
    private string selectedEmulation4 = "Shortcut";
    private string selectedEmulation5 = "Shortcut";
    private string selectedEmulation6 = "Shortcut";
    private string selectedShortcut1 = "Alt";
    private string selectedShortcut2 = "Alt";
    private string selectedShortcut3 = "Alt";
    private string selectedShortcut4 = "Alt";
    private string selectedShortcut5 = "Alt";
    private string selectedShortcut6 = "Alt";
    private string textBox1 = "";
    private string textBox2 = "";
    private string textBox3 = "";
    private string textBox4 = "";
    private string textBox5 = "";
    private string textBox6 = "";
    private Visibility isShortcut1 = Visibility.Visible;
    private Visibility isShortcut2 = Visibility.Visible;
    private Visibility isShortcut3 = Visibility.Visible;
    private Visibility isShortcut4 = Visibility.Visible;
    private Visibility isShortcut5 = Visibility.Visible;
    private Visibility isShortcut6 = Visibility.Visible;
    private Visibility isMessage1 = Visibility.Collapsed;
    private Visibility isMessage2 = Visibility.Collapsed;
    private Visibility isMessage3 = Visibility.Collapsed;
    private Visibility isMessage4 = Visibility.Collapsed;
    private Visibility isMessage5 = Visibility.Collapsed;
    private Visibility isMessage6 = Visibility.Collapsed;
    private string selectedColor = null;
    private string presetName = "";
    public RelayCommand<Preset> SelectCommand { get; set; }
    public RelayCommand CreateCommand { get; set; }
    public RelayCommand DeleteCommand { get; set; }
    public RelayCommand SelectionChanged1 { get; set; }
    public RelayCommand SelectionChanged2 { get; set; }
    public RelayCommand SelectionChanged3 { get; set; }
    public RelayCommand SelectionChanged4 { get; set; }
    public RelayCommand SelectionChanged5 { get; set; }
    public RelayCommand SelectionChanged6 { get; set; }
    public RelayCommand OkCommand { get; set; }

    public string SelectedColor {
      get { return selectedColor; }
      set {
        selectedColor = value;
        RaisePropertyChanged(() => SelectedColor);
      }
    }

    public ObservableCollection<string> PossibleColors {
      get {
        ObservableCollection<string> colors = new ObservableCollection<string>(
          new string[] { "red", "blue", "green", "orange", "yellow", "white", "black", "purple", "gray", "brown" });
        return colors;
      }
    }

    public string PresetName {
      get { return presetName; }
      set {
        presetName = value;
        RaisePropertyChanged(() => PresetName);
      }
    }

    public Visibility IsShortcut1 {
      get { return isShortcut1; }
      set {
        isShortcut1 = value;
        RaisePropertyChanged(() => IsShortcut1);
      }
    }

    public Visibility IsShortcut2 {
      get { return isShortcut2; }
      set {
        isShortcut2 = value;
        RaisePropertyChanged(() => IsShortcut2);
      }
    }

    public Visibility IsShortcut3 {
      get { return isShortcut3; }
      set {
        isShortcut3 = value;
        RaisePropertyChanged(() => IsShortcut3);
      }
    }

    public Visibility IsShortcut4 {
      get { return isShortcut4; }
      set {
        isShortcut4 = value;
        RaisePropertyChanged(() => IsShortcut4);
      }
    }

    public Visibility IsShortcut5 {
      get { return isShortcut5; }
      set {
        isShortcut5 = value;
        RaisePropertyChanged(() => IsShortcut5);
      }
    }
    public Visibility IsShortcut6 {
      get { return isShortcut6; }
      set {
        isShortcut6 = value;
        RaisePropertyChanged(() => IsShortcut6);
      }
    }

    public Visibility IsMessage1 {
      get {
        return isMessage1;
      }
      set {
        isMessage1 = value;
        RaisePropertyChanged(() => IsMessage1);
      }
    }

    public Visibility IsMessage2 {
      get {
        return isMessage2;
      }
      set {
        isMessage2 = value;
        RaisePropertyChanged(() => IsMessage2);
      }
    }
    public Visibility IsMessage3 {
      get {
        return isMessage3;
      }
      set {
        isMessage3 = value;
        RaisePropertyChanged(() => IsMessage3);
      }
    }

    public Visibility IsMessage4 {
      get {
        return isMessage4;
      }
      set {
        isMessage4 = value;
        RaisePropertyChanged(() => IsMessage4);
      }
    }

    public Visibility IsMessage5 {
      get {
        return isMessage5;
      }
      set {
        isMessage5 = value;
        RaisePropertyChanged(() => IsMessage5);
      }
    }

    public Visibility IsMessage6 {
      get {
        return isMessage6;
      }
      set {
        isMessage6 = value;
        RaisePropertyChanged(() => IsMessage6);
      }
    }


    public string TextBox1 {
      get { return textBox1; }
      set {
        textBox1 = value;
        RaisePropertyChanged(() => TextBox1);
      }
    }

    public string TextBox2 {
      get { return textBox2; }
      set {
        textBox2 = value;
        RaisePropertyChanged(() => TextBox2);
      }
    }

    public string TextBox3 {
      get { return textBox3; }
      set {
        textBox3 = value;
        RaisePropertyChanged(() => TextBox3);
      }
    }

    public string TextBox4 {
      get { return textBox4; }
      set {
        textBox4 = value;
        RaisePropertyChanged(() => TextBox4);
      }
    }

    public string TextBox5 {
      get { return textBox5; }
      set {
        textBox5 = value;
        RaisePropertyChanged(() => TextBox5);
      }
    }

    public string TextBox6 {
      get { return textBox6; }
      set {
        textBox6 = value;
        RaisePropertyChanged(() => TextBox6);
      }
    }

    public string SelectedShortcut1 {
      get { return selectedShortcut1; }
      set {
        selectedShortcut1 = value;
        RaisePropertyChanged(() => SelectedShortcut1);
      }
    }

    public string SelectedShortcut2 {
      get { return selectedShortcut2; }
      set {
        selectedShortcut2 = value;
        RaisePropertyChanged(() => SelectedShortcut2);
      }
    }

    public string SelectedShortcut3 {
      get { return selectedShortcut3; }
      set {
        selectedShortcut3 = value;
        RaisePropertyChanged(() => SelectedShortcut3);
      }
    }

    public string SelectedShortcut4 {
      get { return selectedShortcut4; }
      set {
        selectedShortcut4 = value;
        RaisePropertyChanged(() => SelectedShortcut4);
      }
    }

    public string SelectedShortcut5 {
      get { return selectedShortcut5; }
      set {
        selectedShortcut5 = value;
        RaisePropertyChanged(() => SelectedShortcut5);
      }
    }

    public string SelectedShortcut6 {
      get { return selectedShortcut6; }
      set {
        selectedShortcut6 = value;
        RaisePropertyChanged(() => SelectedShortcut6);
      }
    }

    public ObservableCollection<string> ShortcutKeys {
      get { return new ObservableCollection<string>(new string[] { "Alt", "Strg" }); }
    }

    public string SelectedEmulation1 {
      get { return selectedEmulation1; }
      set {
        selectedEmulation1 = value;
        RaisePropertyChanged(() => SelectedEmulation1);
      }
    }
    public string SelectedEmulation2 {
      get { return selectedEmulation2; }
      set {
        selectedEmulation2 = value;
        RaisePropertyChanged(() => SelectedEmulation2);
      }
    }

    public string SelectedEmulation3 {
      get { return selectedEmulation3; }
      set {
        selectedEmulation3 = value;
        RaisePropertyChanged(() => SelectedEmulation3);
      }
    }

    public string SelectedEmulation4 {
      get { return selectedEmulation4; }
      set {
        selectedEmulation4 = value;
        RaisePropertyChanged(() => SelectedEmulation4);
      }
    }

    public string SelectedEmulation5 {
      get { return selectedEmulation5; }
      set {
        selectedEmulation5 = value;
        RaisePropertyChanged(() => SelectedEmulation5);
      }
    }

    public string SelectedEmulation6 {
      get { return selectedEmulation6; }
      set {
        selectedEmulation6 = value;
        RaisePropertyChanged(() => SelectedEmulation6);
      }
    }

    public ObservableCollection<string> EmulationPossiblity {
      get {
        return new ObservableCollection<string>(new string[] { "Shortcut", "Message" });
      }
    }

    public string Button1Text {
      get { return button1Text; }
      set {
        button1Text = value;
        RaisePropertyChanged(() => Button1Text);
      }
    }

    public string Button2Text {
      get { return button2Text; }
      set {
        button2Text = value;
        RaisePropertyChanged(() => Button2Text);
      }
    }

    public string Button3Text {
      get { return button3Text; }
      set {
        button3Text = value;
        RaisePropertyChanged(() => Button3Text);
      }
    }
    public string Button4Text {
      get { return button4Text; }
      set {
        button4Text = value;
        RaisePropertyChanged(() => Button4Text);
      }
    }
    public string Button5Text {
      get { return button5Text; }
      set {
        button5Text = value;
        RaisePropertyChanged(() => Button5Text);
      }
    }

    public string Button6Text {
      get { return button6Text; }
      set {
        button6Text = value;
        RaisePropertyChanged(() => Button6Text);
      }
    }

    public Visibility ErrorVisibility {
      get { return errorVisibility; }
      set {
        errorVisibility = value;
        RaisePropertyChanged(() => ErrorVisibility);
      }
    }
    public string ErrorText {
      get { return errorText; }
      set {
        errorText = value;
        RaisePropertyChanged(() => ErrorText);
      }
    }

    public string ButtonText {
      get { return buttonText; }
      set {
        buttonText = value;
        RaisePropertyChanged(() => ButtonText);
      }
    }

    public ObservableCollection<Preset> Presets {
      get {
        presets = new ObservableCollection<Preset>(bl.GetPresets());
        presets.Insert(0, add);
        return presets;
      }
      set {
        presets = value;
        RaisePropertyChanged(() => Presets);
      }
    }

    public Preset SelectedPreset {
      get {
        return selectedPreset;
      }
      set {
        selectedPreset = value;
        RaisePropertyChanged(() => SelectedPreset);
      }
    }

    private void Select(Preset preset) {
      if (preset != null && preset.name != "+") {
        if (preset.buttons.Count >= 1) {
          Button1Text = preset.buttons[0].name;
          if (preset.buttons[0].assignment.Contains("shortcut:")) {
            IsShortcut1 = Visibility.Visible;
            SelectedEmulation1 = "Shortcut";
            IsMessage1 = Visibility.Visible;
            TextBox1 = preset.buttons[0].assignment.Substring(9);
          } else {
            IsShortcut1 = Visibility.Collapsed;
            IsMessage1 = Visibility.Visible;
            SelectedEmulation1 = "Message";
            TextBox1 = preset.buttons[0].assignment;
          }
        }
        if (preset.buttons.Count >= 2) {
          Button2Text = preset.buttons[1].name;
          if (preset.buttons[1].assignment.Contains("shortcut:")) {
            IsShortcut2 = Visibility.Visible;
            SelectedEmulation2 = "Shortcut";
            IsMessage2 = Visibility.Collapsed;
            TextBox2 = preset.buttons[1].assignment.Substring(9);
          } else {
            IsShortcut2 = Visibility.Collapsed;
            SelectedEmulation2 = "Message";
            IsMessage2 = Visibility.Visible;
            TextBox2 = preset.buttons[1].assignment;
          }
        }
        if (preset.buttons.Count >= 3) {
          Button3Text = preset.buttons[2].name;
          if (preset.buttons[2].assignment.Contains("shortcut:")) {
            IsShortcut3 = Visibility.Visible;
            SelectedEmulation3 = "Shortcut";
            IsMessage3 = Visibility.Visible;
            TextBox3 = preset.buttons[2].assignment.Substring(9);
          } else {
            IsShortcut3 = Visibility.Collapsed;
            SelectedEmulation3 = "Message";
            IsMessage3 = Visibility.Visible;
            TextBox3 = preset.buttons[2].assignment;
          }
        }
        if (preset.buttons.Count >= 4) {
          Button4Text = preset.buttons[3].name;
          if (preset.buttons[3].assignment.Contains("shortcut:")) {
            IsShortcut4 = Visibility.Visible;
            SelectedEmulation4 = "Shortcut";
            IsMessage4 = Visibility.Visible;
            TextBox4 = preset.buttons[3].assignment.Substring(9);
          } else {
            IsShortcut4 = Visibility.Collapsed;
            IsMessage4 = Visibility.Visible;
            SelectedEmulation4 = "Message";
            TextBox4 = preset.buttons[3].assignment;
          }
        }
        if (preset.buttons.Count >= 5) {
          Button5Text = preset.buttons[4].name;
          if (preset.buttons[4].assignment.Contains("shortcut:")) {
            IsShortcut5 = Visibility.Visible;
            IsMessage5 = Visibility.Visible;
            SelectedEmulation5 = "Shortcut";
            TextBox5 = preset.buttons[4].assignment.Substring(9);
          } else {
            IsShortcut5 = Visibility.Collapsed;
            SelectedEmulation5 = "Message";
            IsMessage5 = Visibility.Visible;
            TextBox5 = preset.buttons[4].assignment;
          }
        }
        if (preset.buttons.Count == 6) {
          Button6Text = preset.buttons[5].name;
          if (preset.buttons[5].assignment.Contains("shortcut:")) {
            IsShortcut6 = Visibility.Visible;
            IsMessage6 = Visibility.Visible;
            SelectedEmulation6 = "Shortcut";
            TextBox6 = preset.buttons[5].assignment.Substring(9);
          } else {
            IsShortcut6 = Visibility.Collapsed;
            IsMessage6 = Visibility.Visible;
            SelectedEmulation6 = "Message";
            TextBox6 = preset.buttons[5].assignment;
          }
        }
        PresetName = preset.name;
        SelectedColor = preset.color;
        ButtonText = "Updaten";
      } else {
        Button1Text = "Button-name";
        Button2Text = "Button-name";
        Button3Text = "Button-name";
        Button4Text = "Button-name";
        Button5Text = "Button-name";
        Button6Text = "Button-name";
        IsShortcut1 = Visibility.Visible;
        IsShortcut2 = Visibility.Visible;
        IsShortcut3 = Visibility.Visible;
        IsShortcut4 = Visibility.Visible;
        IsShortcut5 = Visibility.Visible;
        IsShortcut6 = Visibility.Visible;
        IsMessage1 = Visibility.Collapsed;
        IsMessage2 = Visibility.Collapsed;
        IsMessage3 = Visibility.Collapsed;
        IsMessage4 = Visibility.Collapsed;
        IsMessage5 = Visibility.Collapsed;
        IsMessage6 = Visibility.Collapsed;
        SelectedEmulation1 = "Shortcut";
        SelectedEmulation2 = "Shortcut";
        SelectedEmulation3 = "Shortcut";
        SelectedEmulation4 = "Shortcut";
        SelectedEmulation5 = "Shortcut";
        SelectedEmulation6 = "Shortcut";
        TextBox1 = "";
        TextBox2 = "";
        TextBox3 = "";
        TextBox4 = "";
        TextBox5 = "";
        TextBox6 = "";
        ButtonText = "Hinzufügen";
        PresetName = "";
        SelectedColor = null;
      }
    }

    private Preset CreatePreset() {
      Button b1 = null;
      Button b2 = null;
      Button b3 = null;
      Button b4 = null;
      Button b5 = null;
      Button b6 = null;
      if (selectedEmulation1 == "Shortcut" && presetName != null && presetName != "")
        b1 = new Button(-1, button1Text, "shortcut:" + selectedShortcut1 + "+" + textBox1);
      else
        b1 = new Button(-1, button1Text, textBox1);
      if (selectedEmulation2 == "Shortcut" && presetName != null && presetName != "")
        b1 = new Button(-1, button2Text, "shortcut:" + selectedShortcut2 + "+" + textBox2);
      else
        b1 = new Button(-1, button2Text, textBox2);
      if (selectedEmulation3 == "Shortcut" && presetName != null && presetName != "")
        b1 = new Button(-1, button3Text, "shortcut:" + selectedShortcut3 + "+" + textBox3);
      else
        b1 = new Button(-1, button3Text, textBox3);
      if (selectedEmulation4 == "Shortcut" && presetName != null && presetName != "")
        b1 = new Button(-1, button4Text, "shortcut:" + selectedShortcut4 + "+" + textBox4);
      else
        b1 = new Button(-1, button4Text, textBox4);
      if (selectedEmulation5 == "Shortcut" && presetName != null && presetName != "")
        b1 = new Button(-1, button5Text, "shortcut:" + selectedShortcut5 + "+" + textBox5);
      else
        b1 = new Button(-1, button5Text, textBox5);
      if (selectedEmulation6 == "Shortcut" && presetName != null && presetName != "")
        b1 = new Button(-1, button6Text, "shortcut:" + selectedShortcut6 + "+" + textBox6);
      else
        b1 = new Button(-1, button6Text, textBox6);
      IList<Button> buttons = new List<Button>(new Button[] { b1, b2, b3, b4, b5, b6 });
      Preset preset = new Preset(-1, presetName, selectedColor, buttons);
      return preset;
    }

    private void ShowError(string mode) {
      ErrorVisibility = Visibility.Visible;
      if (mode == "Create")
        ErrorText = "Der Entwurf konnte nicht hinzugefügt werden!\nMögliche Ursachen:\n1) Der Entwurf existiert bereits\n" +
          "2) Die Konventionen der Message wurde nicht eingehalten [Message <= 50 Zeichen]\n" +
          "3) Die Konventionen des Shortcuts wurde nicht eingehalten [Shortcut <= 35 Zeichen]\n" +
          "4) Die Konventionen des Entwurfsnamen wurde nicht eingehalten [Entwurfsname <= 30 Zeichen]\n" +
          "5) Der Entwurfname ist leer";
      else if (mode == "Update")
        ErrorText = "Der Entwurf konnte nicht upgedated werden!\nMögliche Ursachen:\n" +
          "1) Die Konventionen der Message wurde nicht eingehalten [Message <= 50 Zeichen]\n" +
          "2) Die Konventionen des Shortcuts wurde nicht eingehalten [Shortcut <= 35 Zeichen]\n" +
          "3) Die Konventionen des Entwurfsnamen wurde nicht eingehalten [Entwurfsname <= 30 Zeichen]\n" +
          "4) Der Entwurfname ist leer\n" +
          "5) Keine Änderungen";
      else {
        ErrorText = "Der Entwurf konnte nicht gelöscht werden!\nMögliche Ursachen:\n" +
          "1) Der Entwurf konnte nicht gefunden werden";
      }
    }

    private void Create() {
      if (ButtonText == "Anlegen") {
        if (bl.InsertPresetEager(CreatePreset()) == false) {
          ShowError("Create");
        } else {
          presets.Add(CreatePreset());
          Presets = presets;
          SelectedPreset = new Preset(-1, "+", "", new List<Button>());
        }
      } else {
        if (bl.UpdatePresetEager(CreatePreset()) == false) {
          ShowError("Update");
        } else {
          int i = 0;
          foreach (var preset in presets) {
            if (preset.id == CreatePreset().id) {
              presets.Remove(preset);
              presets.Insert(i, CreatePreset());
              Presets = presets;
              break;
            }
            i++;
          }
        }
      }
    }

    private void Delete() {
      if (bl.DeletePresetEager(CreatePreset()) == false) {
        ShowError("Delete");
      } else {
        presets.Remove(CreatePreset());
      }
    }

    private void Ok() {
      ErrorVisibility = Visibility.Collapsed;
      ErrorText = "";
    }

    private void Changed1() {
      if (selectedEmulation1 == "Shortcut") {
        IsShortcut1 = Visibility.Visible;
        IsMessage1 = Visibility.Collapsed;
      } else {
        IsShortcut1 = Visibility.Collapsed;
        IsMessage1 = Visibility.Visible;
      }
    }

    private void Changed2() {
      if (selectedEmulation2 == "Shortcut") {
        IsShortcut2 = Visibility.Visible;
        IsMessage2 = Visibility.Collapsed;
      } else {
        IsShortcut2 = Visibility.Collapsed;
        IsMessage2 = Visibility.Visible;
      }
    }

    private void Changed3() {
      if (selectedEmulation3 == "Shortcut") {
        IsShortcut3 = Visibility.Visible;
        IsMessage3 = Visibility.Collapsed;
      } else {
        IsShortcut3 = Visibility.Collapsed;
        IsMessage3 = Visibility.Visible;
      }
    }

    private void Changed4() {
      if (selectedEmulation4 == "Shortcut") {
        IsShortcut4 = Visibility.Visible;
        IsMessage4 = Visibility.Collapsed;
      } else {
        IsShortcut4 = Visibility.Collapsed;
        IsMessage4 = Visibility.Visible;
      }
    }

    private void Changed5() {
      if (selectedEmulation5 == "Shortcut") {
        IsShortcut5 = Visibility.Visible;
        IsMessage5 = Visibility.Collapsed;
      } else {
        IsShortcut5 = Visibility.Collapsed;
        IsMessage5 = Visibility.Visible;
      }
    }

    private void Changed6() {
      if (selectedEmulation6 == "Shortcut") {
        IsShortcut6 = Visibility.Visible;
        IsMessage6 = Visibility.Collapsed;
      } else {
        IsShortcut6 = Visibility.Collapsed;
        IsMessage6 = Visibility.Visible;
      }
    }

    public PresetViewModel() {
      selectedPreset = add;
      SelectCommand = new RelayCommand<Preset>(Select);
      CreateCommand = new RelayCommand(Create);
      DeleteCommand = new RelayCommand(Delete);
      OkCommand = new RelayCommand(Ok);
      SelectionChanged1 = new RelayCommand(Changed1);
      SelectionChanged2 = new RelayCommand(Changed2);
      SelectionChanged3 = new RelayCommand(Changed3);
      SelectionChanged4 = new RelayCommand(Changed4);
      SelectionChanged5 = new RelayCommand(Changed5);
      SelectionChanged6 = new RelayCommand(Changed6);
    }
  }
}