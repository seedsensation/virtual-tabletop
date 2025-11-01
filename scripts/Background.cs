using Godot;
using System;
using System.IO;
using System.Net;


public partial class Background : TextureRect
{
	public int select;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void chooseBackground(int choice)
	{
		select = choice;
		if (select == 0)
		{
			var texture = GD.Load<Texture2D>("Backgrounds/dirkTest.png");
			this.Texture = texture;
		}
		else if (select == 1)
		{
			var texture = GD.Load<CompressedTexture2D>("Backgrounds/cavefloor.png");
			this.Texture = texture;
		}
		else
		{
			var texture = GD.Load<CompressedTexture2D>("Backgrounds/town.png");
			this.Texture = texture;
		}

	}
}
