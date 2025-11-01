using Godot;
using System;
using System.Collections.Generic;

public partial class DiceButton : Button
{
	[Export]
	public int diceType;
	[Export]
	public int counter;

	public virtual void counterChange(InputEvent inputEvent)
	{
		if (inputEvent is InputEventMouseButton mouseEvent)
			if (mouseEvent.IsReleased())
			{
				if (mouseEvent.ButtonIndex == MouseButton.Left)
				{
				counter++;
				}
				else if (mouseEvent.ButtonIndex == MouseButton.Right && counter > 0)
				{
				counter--;
				}
				CounterLabel counterLabel = (CounterLabel)this.GetChild(0);
				counterLabel.updateText((int)counter);
			}
		

	}
}
