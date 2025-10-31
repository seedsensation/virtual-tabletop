using Godot;
using System;

public partial class CounterLabel : Label
{
	public void updateText(int counter)
	{
		this.Text = Convert.ToString(counter);
	}
}
