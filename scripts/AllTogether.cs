using Godot;
using System;

public partial class AllTogether : Node2D
{
	public void ShowSystemMenu() {
		GetNode<Control>("System Editor").Visible = true;
	}


	//
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
