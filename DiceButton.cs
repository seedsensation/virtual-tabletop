using Godot;
using System;

public partial class DiceButton : Button
{
	[Export]
	public int diceType;
	[Export]
	public int counter;

	public void counterChange(InputEventMouseButton mouseButton)
	{
		if (mouseButton.IsReleased())
		{
			if (mouseButton.ButtonIndex == MouseButton.Left)
			{
			counter++;
			GD.Print(counter);
			}
			else if (mouseButton.ButtonIndex == MouseButton.Right && counter > 0)
			{
			counter--;
			GD.Print(counter);
			}
		}
		

	}
}
