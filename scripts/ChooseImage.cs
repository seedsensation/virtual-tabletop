using Godot;
using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks.Dataflow;

public partial class ChooseImage : OptionButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		string tempsize = "Backgrounds";
		string[] images = Directory.GetFiles(tempsize);
		for (int i = 0; i < images.Length; i++)
		{
			this.AddItem(images[i].Remove(0, 12));
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void pickBackground(int index)
	{
	} 

}
