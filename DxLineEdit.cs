using Godot;
using System;

public partial class DxLineEdit : LineEdit
{
	public void deselectLineEdit(InputEvent input)
	{
		if (input is InputEventMouseButton)
		{
			this.ReleaseFocus();
		}
	}

	//When a number is input, update dicetype to be the input integer

	public void validateInput(string newText)
	{
		int diceValue;
		try
		{
			diceValue = Convert.ToInt32(newText);
			if (diceValue < 1)
			{
				this.Clear();
			}
		}
		catch (System.Exception)
		{
			this.Clear();
		}
	}
}
