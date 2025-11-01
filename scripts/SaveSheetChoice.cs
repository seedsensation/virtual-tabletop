using Godot;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.IO;

public partial class SaveSheetChoice : Button
{
	string playerSheet, enemySheet, dice; 

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
		selectCharSheet selectCharacter = GetNode<selectCharSheet>("SelectSheetPlayer");
		playerSheet = selectCharacter.chosenPlayerSheet;

		selectCharSheet SelectEnemy = GetNode<selectCharSheet>("SelectSheetEnemy");
		enemySheet = SelectEnemy.chosenEnemySheet;

		DiceType DiceType = GetNode<DiceType>("DiceTypeDbx");
		dice = DiceType.diceSelected;

		Dictionary<string, string> systemData = new Dictionary<string, string>();
		systemData.Add("SystemTitle", GetNode<TextEdit>("SystemName").Text);
		systemData.Add("playerCharacterSheet", playerSheet);
		systemData.Add("EnemyCharacterSheet", enemySheet);
		systemData.Add("DiceType", dice);

		string fileData;
		fileData = JsonSerializer.Serialize(systemData);

		GD.Print(fileData);
		
		StreamWriter writeData = new StreamWriter("data/SystemData.json");
		writeData.WriteLine(fileData);
		writeData.Close();
		
	}
}
