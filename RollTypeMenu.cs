using Godot;
using System;

public partial class RollTypeMenu : Control
{
	[Export]
	public int x = 1;

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
}
