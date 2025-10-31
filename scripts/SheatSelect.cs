using Godot;
using System;
using System.IO;
using System.Runtime.ExceptionServices;

public partial class SheatSelect : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//select the sheats from the files
		chooseSheats();
	}

	public void chooseSheats()
	{
		string[] fileNames = Directory.GetFiles("data");
		for (int i = 0; i < fileNames.Length; i++)
		{
			
		}
	}
}
