using Godot;
using System;
using VirtualTabletop.Types;
namespace VirtualTabletop.Sheets;

[Tool]
public partial class SheetCreatorPanel : Control
{
	[Signal]
	public delegate void MovedUpEventHandler();
	[Signal]
	public delegate void MovedDownEventHandler();
	private int _index = 0;
	[Export]
	public int index {
		get {
			return _index;
		}
		set {
			_index = value;
			Button upButton = (Button)GetNode("UpButton");
			Button downButton = (Button)GetNode("DownButton");
			upButton.Disabled = (_index == 0);
			downButton.Disabled = (_index == arrayLength-1);

		}
	}

	[Export]
	public int arrayLength = 1;
	private bool _deleteEnabled = true;
	[Export]
	public bool deleteEnabled {
		get {
			return _deleteEnabled;
		}
		set {
			Button DeleteButton = (Button)GetNode("DeleteButton");
			DeleteButton.Disabled = _deleteEnabled;
			_deleteEnabled = !_deleteEnabled;


		}
	}
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

	public void UpButton() {
		EmitSignal(SignalName.MovedUp);
	}
	public void DownButton() {
		EmitSignal(SignalName.MovedDown);

	}

	public void DeleteButtonPressed() {
		this.QueueFree();

	}
}
