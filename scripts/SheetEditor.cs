using Godot;
using System;
using System.Linq;

public partial class SheetEditor : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	public void NewPanel() {
		// create a new panel
		var scene = (Control)GD.Load<PackedScene>("res://panel.tscn").Instantiate();
		GetNode("ScrollContainer/PanelContainer").AddChild(scene);
	}

	public void RefreshPanelIndices() {
		foreach(Node child in GetNode("ScrollContainer/PanelContainer").GetChildren()) {
			if (child is )
		}
	}
	public void PanelMovedUp() {

	}
	public void PanelMovedDown() {

	}
}
