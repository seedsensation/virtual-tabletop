using Godot;
using System;
using System.Collections.Generic;

public partial class DiceXButton : DiceButton
{
	public void updateDiceType(string textInput)
	{
		int diceValue;
		try
		{
			diceValue = Convert.ToInt32(textInput);
			if (diceValue > 0)
			{
				diceType = diceValue;
			}
			else
			{
				diceType = 0;
			}
		}
		catch (System.Exception)
		{
			diceType = 0;
		}
	}

	public override void counterChange(InputEvent inputEvent)
	{
		if (diceType > 0)
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
}
