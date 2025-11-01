using Godot;
using System;

public partial class SystemEditor : Control
{
	public void NewSheet() {
		GetNode<Control>("SystemMenu").Visible = false;
		GetNode<Control>("SheetEditor").Visible = true;
		GetNode<Control>("CharacterSheet").Visible = false;
	}

	public void SubmittedSheet() {
		GetNode<Control>("SystemMenu").Visible = true;
		GetNode<Control>("SheetEditor").Visible = false;
		GetNode<selectCharSheet>("SystemMenu/SaveSheetChoice/SelectSheetPlayer").ResetSheets();
	}

	public void CharacterSheetClosed() {
		GD.Print("Character Sheet Closed");
		GetNode<Control>("SystemMenu").Visible = true;
		GetNode<Control>("SheetEditor").Visible = false;
		GetNode<Control>("CharacterSheet").Visible = false;
	}

	public void LoadCharacterSheet() {
		OptionButton PlayerSheet = (OptionButton)this.GetNode("SystemMenu/SaveSheetChoice/SelectSheetPlayer");
		string FileName = ProjectSettings.GlobalizePath("user://" + PlayerSheet.GetItemText(PlayerSheet.GetSelectedId()));
		var CharacterSheet = GetNode<VirtualTabletop.Types.CharacterSheet>("CharacterSheet");
		CharacterSheet.FileName = FileName;
		CharacterSheet.UpdateSheet();
		CharacterSheet.Visible = true;
		GetNode<Control>("SystemMenu").Visible = false;
	}

	public void Close() {
		this.Visible = false;
	}

	public void UpdatedText() {
		GetNode<VirtualTabletop.Sheets.SheetEditor>("SheetEditor").FolderName = GetNode<TextEdit>("SystemMenu/SaveSheetChoice/SystemName").Text;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
