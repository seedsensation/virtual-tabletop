using Godot;
using System;

public partial class DiceButton : Button
{
	[Export]
	public int diceType;
	[Export]
	public int counter;

	public void counterChange(InputEvent inputEvent)
	{
		if (inputEvent is InputEventMouseButton mouseEvent)
			if (mouseEvent.IsReleased())
			{
				if (mouseEvent.ButtonIndex == MouseButton.Left)
				{
				counter++;
				GD.Print(counter);
				}
				else if (mouseEvent.ButtonIndex == MouseButton.Right && counter > 0)
				{
				counter--;
				GD.Print(counter);
				}
			}
		

	}
}
