using Godot;
using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;
using System.Linq;

public partial class selectCharSheet : OptionButton
{
	// Called when the node enters the scene tree for the first time.
	public string chosenPlayerSheet, chosenEnemySheet;
	public override void _Ready()
	{
		//select the sheats from the files
		chooseSheats();
		readChoice(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void chooseSheats()
	{
		string[] fileNames = Directory.GetFiles(ProjectSettings.GlobalizePath("user://"));
		GD.Print(GetParent().GetNode<TextEdit>("SystemName").Text);
		var fileNamesCollection =
			from file in fileNames
			where file.GetFile().ToLower().StartsWith(GetParent().GetNode<TextEdit>("SystemName").Text.ToLower())
			where file.GetExtension() == "json"
			select file.GetFile();

		foreach ( string i in fileNamesCollection) {
			GD.Print(i);
			this.AddItem(i);
		}
	}

	public void ResetSheets() {
		this.Clear();
		this.chooseSheats();
	}

	public void readChoice(int index)
	{
		if (this.Name == "SelectSheetPlayer")
		{
			chosenPlayerSheet = GetItemText(index);
			changeValue(chosenPlayerSheet);
		}
		else
		{
			chosenEnemySheet = GetItemText(index);
			changeValue(chosenEnemySheet);
		}
	}
	public string changeValue(string sheet)
	{
		return sheet;
	}
}
