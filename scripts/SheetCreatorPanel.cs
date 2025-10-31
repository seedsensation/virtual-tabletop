using Godot;
using System;
using VirtualTabletop.Types;
namespace VirtualTabletop.Sheets;

public partial class SheetCreatorPanel : Panel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ItemSelected(int index) {
		SheetType type = (SheetType)index;
		GD.Print(index);
		Label title = (Label)GetNode("Demonstration");
		title.Text = type switch {
			SheetType.TypeInt => "10",
			SheetType.TypeFloat => "1.5",
			SheetType.TypeString => "Hello World",
			SheetType.TypeBool => "[  ]",
			SheetType.TypeDepletable => "10 / 15"
			};
	}
}
