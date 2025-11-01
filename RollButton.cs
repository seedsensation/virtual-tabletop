using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class RollButton : Button
{
	[Signal]
	public delegate void buttonPressedEventHandler();

	public void rollDice()
	{
		Random rand = new Random();
		List<int> diceResults = new List<int>();
		
		foreach (DiceButton diceButton in GetChildren())
		{
			//for each time the counter has been incremented, roll a dice
			if (diceButton.counter > 0)
			{
				for (int count = 0; count < diceButton.counter; count++)
				{
					diceResults.Add(rand.Next(1, diceButton.diceType));
				}
			}
			
		}
		int i = 0;
		RollTypeMenu typeSelected = GetParent().GetNode<RollTypeMenu>("RollType");
		FaLineEdit flatNumber = GetParent().GetNode("FlatAddition_Button").GetNode<FaLineEdit>("FA_LineEdit");
		int valueX = typeSelected.x;
		int setting = typeSelected.rollFunction;
		int flatNum;
		try
		{
			flatNum = Convert.ToInt32(flatNumber.Text);
		}
		catch
		{
			flatNum = 0;
		}
		switch (setting)
		{
			case 0:
				int total = 0;
				foreach (int result in diceResults)
				{
					GD.Print(diceResults[i]);
					total += diceResults[i];
					i++;
				}
				GD.Print("Total: " + Convert.ToString(total + flatNum));
				break;

			case 1:
				int iH = 0;
				foreach (int result in diceResults)
				{
					GD.Print(diceResults[iH]);
					
					iH++;
				}
				diceResults.Sort();
				diceResults.Reverse();
				string outputHighest = "Highest " + Convert.ToString(valueX) + " dice: ";
				for (int iHighest = 0; iHighest < valueX; iHighest++)
				{
					if (iHighest != 0)
					{
						outputHighest = outputHighest + ", ";
					}
					outputHighest = outputHighest + Convert.ToString(diceResults[iHighest]);
				}
				GD.Print(outputHighest);
				break;

			case 2:
				int iL = 0;
				foreach (int result in diceResults)
				{
					GD.Print(diceResults[iL]);
					
					iL++;
				}
				diceResults.Sort();
				diceResults.Reverse();
				string outputLowest = "Lowest " + Convert.ToString(valueX) + " dice: ";
				for (int iLowest = 0; iLowest < valueX; iLowest++)
				{
					if (iLowest != 0)
					{
						outputLowest = outputLowest + ", ";
					}
					outputLowest = outputLowest + Convert.ToString(diceResults[iLowest]);
				}
				GD.Print(outputLowest);
				break;

			case 3:
				int countH = 0;
				foreach (int result in diceResults)
				{
					GD.Print(diceResults[i]);
					if (diceResults[i] >= valueX)
					{
						countH++;
					}
					i++;
				}
				GD.Print(Convert.ToString(countH) + " dice rolled " + Convert.ToString(valueX) + " or higher");
				break;
			
			case 4:
				int countL = 0;
				foreach (int result in diceResults)
				{
					GD.Print(diceResults[i]);
					if (diceResults[i] <= valueX)
					{
						countL++;
					}
					i++;
				}
				GD.Print(Convert.ToString(countL) + " dice rolled " + Convert.ToString(valueX) + " or lower");
				break;
		}

		foreach (DiceButton diceButton in GetChildren())
		{
			diceButton.counter = 0;
			CounterLabel counterLabel = (CounterLabel)diceButton.GetChild(0);
			counterLabel.updateText((int)diceButton.counter);
		}
		
		EmitSignal(SignalName.buttonPressed);
	}
	
	//I need to write different functionality depending on the roll type selected
	//write an export property thing for rollmenu, probably an int
	//then, same as I did with X, move that over here?
	//then switch into different code depending on what mode is selected
	//sum = total everything together
	//highest = find highest and output that
	//lowest = same as above
	//count = loop through list and increment counter each time requirement is met
	//then output that nicely into a rich text label so that it has a scroll wheel
	//pretty everything up


	public override void _Ready()
	{
		Random rand = new Random();
	}
}
