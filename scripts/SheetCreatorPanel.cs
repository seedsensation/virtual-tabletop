using Godot;
using System;
using VirtualTabletop.Types;
namespace VirtualTabletop.Sheets;

[Tool]
public partial class SheetCreatorPanel : Control
{
	[Signal]
	public delegate void MovedUpEventHandler(int index);
	[Signal]
	public delegate void MovedDownEventHandler(int index);
	private int _index = 0;
	private int _arrayLength = 1;
	public int index {
		get {
			return _index;
		}
		set {
			_index = value;
			refreshButtons();
		}
	}
	public int arrayLength {
		get {
			return _arrayLength;
		}
		set {
			_arrayLength = value;
			refreshButtons();
		}
	}

	private void refreshButtons() {
			Button upButton = (Button)GetNode("UpButton");
			Button downButton = (Button)GetNode("DownButton");
			upButton.Disabled = (_index == 0);
			downButton.Disabled = (_index == _arrayLength-1);

	}

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
			SheetType.TypeDepletable => "10 / 15",
			SheetType.TypeHeader => "Section Heading"
			};
	}

	public void UpButton() {
		EmitSignal(SignalName.MovedUp, index);
	}
	public void DownButton() {
		EmitSignal(SignalName.MovedDown, index);

	}

	public void DeleteButtonPressed() {
		this.QueueFree();

	}
}
