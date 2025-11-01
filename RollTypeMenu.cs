using Godot;
using System;

public partial class RollTypeMenu : Control
{
	[Export]
	public int x = 1;
	[Export]
	public int rollFunction = 0;

	public void toggleVisibility()
	{
		this.Visible = true;
	}
	
	public void confirmClicked()
	{
		this.Visible = false;
	}

	public void updateX(int inputValue)
	{
		this.x = (inputValue);
	}
	
	public void updateFunction(int selectedFunction)
	{
		this.rollFunction = (selectedFunction);
	}
}
