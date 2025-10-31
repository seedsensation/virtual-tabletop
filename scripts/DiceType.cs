using Godot;
using System;
using System.Threading.Tasks.Dataflow;

public partial class DiceType : OptionButton
{
	[Export]
	public string diceSelected;
	string currentDice, tempDice;
	int index;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Select(0);
		currentDice = GetItemText(index);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	
	}

	public void itemSelected(int index)
	{
		currentDice = GetItemText(index);
		if (currentDice != tempDice)
		{
			diceSelected = currentDice;
		}

		tempDice = currentDice;
	}

}
