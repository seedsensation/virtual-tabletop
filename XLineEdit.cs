using Godot;
using System;

public partial class XLineEdit : LineEdit
{
	[Signal]
	public delegate void xValueUpdatedEventHandler(int xValue);

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
				this.Text = "1";
				EmitSignal(SignalName.xValueUpdated, 1);
			}
			else
			{
				EmitSignal(SignalName.xValueUpdated, newText);
			}
		}
		catch (System.Exception)
		{
			this.Text = "1";
			EmitSignal(SignalName.xValueUpdated, 1);
		}
	}
}
