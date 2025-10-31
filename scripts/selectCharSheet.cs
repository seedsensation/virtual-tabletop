using Godot;
using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks.Dataflow;

public partial class selectCharSheet : OptionButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//select the sheats from the files
		chooseSheats();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void chooseSheats()
	{
		string[] fileNames = Directory.GetFiles("data");
		for (int i = 0; i < fileNames.Length; i++)
		{
			this.AddItem(fileNames[i].Remove(0,5));
		}
	}
}
