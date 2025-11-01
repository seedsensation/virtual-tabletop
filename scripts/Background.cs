using Godot;
using System;


public partial class Background : TextureRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var texture = GD.Load<CompressedTexture2D>("Backgrounds/dirkTest.png");
		this.Texture = texture;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
