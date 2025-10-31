using Godot;
using System;

public partial class DiceInterface : Control
{
	//OKAY
	//dice random bullshit idk

	

	//The structure of this thing

	//starting with ONE DICE BEING ROLLED
	//look at the dice # being rolled
	//rand.Next(1, dicenumber)
	//this includes if you input a custom dice number
	//but check that it's not negative first pretty please I'm not calculating that
	//then, you might need to roll multiple dice
	//for each different dice type
	//for every dice rolled
	//generate random number and shove into a list
	//then output list in chronological order (don't reorder, it won't feel natural)
	//you can perform operations on the list depending on requested output
	//including highlighting the highest and so on
	
	public void toggleVisibility()
	{
		this.Visible = !this.Visible;
	}
	
}
