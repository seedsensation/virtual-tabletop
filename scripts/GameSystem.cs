using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;


public partial class GameSystem : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Dictionary<int, string> SystemData = new Dictionary<int, string>();
		SystemData.Add(5, "hello");
		string temp;
		temp = JsonSerializer.Serialize(SystemData);
		GD.Print(temp);
		//pick a template for characters

		//
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
