using Godot;
using System;
using System.Collections.Generic;

public partial class RollButton : Button
{
	public void rollDice()
	{
		Random rand = new Random();
		List<int> diceResults = new List<int>();
		
		foreach (DiceButton diceButton in GetChildren())
		{
			//for each time the counter has been incremented, roll a dice
			if (diceButton.counter > 0)
			{
				for (int count = 0; count < diceButton.counter; count++)
				{
					diceResults.Add(rand.Next(1, diceButton.diceType));
				}
			}
			
		}
		int i = 0;
		foreach (int result in diceResults)
		{
			GD.Print(diceResults[i]);
			i++;
		}
		
	}
	

	public override void _Ready()
	{
		Random rand = new Random();
	}
}
