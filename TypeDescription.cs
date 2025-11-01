using Godot;
using System;

public partial class TypeDescription : Label
{
	public void updateText(int type)
	{
		switch (type)
		{
			case 0:
				this.Text = "Sums all rolls and displays the total.";
				break;
			case 1:
				this.Text = "Keeps the highest x dice and totals them.";
				break;
			case 2:
				this.Text = "Keeps the lowest x dice and totals them.";
				break;
			case 3:
				this.Text = "Counts all dice that roll x or higher.";
				break;
			case 4:
				this.Text = "Counts all dice that roll x or lower.";
				break;
		}
	}
	
}
