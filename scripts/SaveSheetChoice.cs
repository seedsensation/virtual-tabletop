using Godot;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.IO;

public partial class SaveSheetChoice : Button
{
	string PlayerSheet, EnemySheet, Dice; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void saveChoice()
	{
		selectCharSheet selectCharacter = (selectCharSheet)this.GetChild(0);
		PlayerSheet = selectCharacter.chosenPlayerSheet;

		selectCharSheet SelectEnemy = (selectCharSheet)this.GetChild(1);
		EnemySheet = SelectEnemy.chosenEnemySheet;

		DiceType DiceType = (DiceType)this.GetChild(2);
		Dice = DiceType.diceSelected;

		Dictionary<string, string> systemData = new Dictionary<string, string>();
		systemData.Add("playerCharacterSheet", PlayerSheet);
		systemData.Add("EnemyCharacterSheet", EnemySheet);
		systemData.Add("DiceType", Dice);

		string fileData;
		fileData = JsonSerializer.Serialize(systemData);

		GD.Print(fileData);
		
		StreamWriter writeData = new StreamWriter("data/SystemData.json");
		writeData.WriteLine(fileData);
		writeData.Close();
		
	}
}
