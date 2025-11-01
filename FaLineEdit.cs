using Godot;
using System;

public partial class FaLineEdit : LineEdit
{
	public void validateInput(string newText)
	{
		int diceValue;
		try
		{
			diceValue = Convert.ToInt32(newText);
		}
		catch (System.Exception)
		{
			if (newText != "-")
			{
				this.Clear();
			}
		}
	}

	public void resetValue()
	{
		this.Clear();
	}
}
