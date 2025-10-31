using Godot;
using System;

public partial class RollButton : Button
{
	public void rollDice()
	{
		foreach (DiceButton diceButton in GetChildren())
		{
			GD.Print("Hi");
		}
	}
	

	//public override void _Ready()
	//{
	//	Random rand = new Rand();
	//}
}
