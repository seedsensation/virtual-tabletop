using Godot;
using System;

public partial class SystemEditor : Control
{
	public void NewSheet() {
		GetNode<Control>("SystemMenu").Visible = false;
		GetNode<Control>("SheetEditor").Visible = true;
	}

	public void SubmittedSheet() {
		GetNode<Control>("SystemMenu").Visible = true;
		GetNode<Control>("SheetEditor").Visible = false;
		GetNode<selectCharSheet>("SystemMenu/SaveSheetChoice/SelectSheetPlayer").ResetSheets();

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
