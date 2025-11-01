using Godot;
using System;
using System.Text.Json;
using System.Collections.Generic;
namespace VirtualTabletop.Types;


public partial class CharacterSheet : Control
{
	[Signal]
	delegate void WindowClosedEventHandler();


	[Export]
	public string FileName;
	public override void _Ready() {
		SheetTemplate test = new SheetTemplate();
		test.fields.Add(new Field("aw",SheetType.TypeString));
		test.fields.Add(new Field("yeah",SheetType.TypeInt));
		GD.Print(JsonSerializer.Serialize(test));
		UpdateSheet();
	}

	public void Close() {
		this.Visible = false;
		EmitSignal(SignalName.WindowClosed);
	}

	public void UpdateSheet() {
		GD.Print("Now Deserializing");
		foreach ( Node child in this.GetNode("VScrollBar/VBoxContainer").GetChildren() ) {
			child.QueueFree();
		}
		GD.Print(FileName);
		using var file = FileAccess.Open(FileName, FileAccess.ModeFlags.Read);
		string content = file.GetAsText();
		GD.Print(content);
		SheetTemplate template = JsonSerializer.Deserialize<SheetTemplate>(content);
		foreach (Field i in template.fields) {
			GD.Print(i.title);
			Control scene;
			switch (i.type) {
				case SheetType.TypeInt:
					scene = (Control)GD.Load<PackedScene>("res://SheetComponents/Int.tscn").Instantiate();
					break;
				case SheetType.TypeFloat:
					scene = (Control)GD.Load<PackedScene>("res://SheetComponents/Float.tscn").Instantiate();
					break;
				case SheetType.TypeString:
					scene = (Control)GD.Load<PackedScene>("res://SheetComponents/String.tscn").Instantiate();
					break;
				case SheetType.TypeBool:
					scene = (Control)GD.Load<PackedScene>("res://SheetComponents/Bool.tscn").Instantiate();
					break;
				case SheetType.TypeDepletable:
					scene = (Control)GD.Load<PackedScene>("res://SheetComponents/Depletable.tscn").Instantiate();
					break;
				case SheetType.TypeHeader:
				default:
					scene = (Control)GD.Load<PackedScene>("res://SheetComponents/Header.tscn").Instantiate();
					break;
			}

			scene.GetNode<Label>("Label").Text = i.title;
			GD.Print(scene.GetNode<Label>("Label").Text);
			this.GetNode("VScrollBar/VBoxContainer").AddChild(scene);

		}
	}
}


public enum SheetType : int {
	TypeInt = 1,
	TypeFloat = 2,
	TypeString = 3,
	TypeBool = 4,
	TypeDepletable = 5,
	TypeHeader = 6,
}

public class SheetTemplate {
	public int id {get; set;}
	public string title {get; set;}

	public List<Field> fields {get; set;}



	public SheetTemplate() {
		id = 1;
		fields = [];
	}
}

public class Field {
	public int id {get; set;}
	public SheetType type {get; set;}
	public string title {get; set;}

	public Field(string title, SheetType type) {
		this.id = new Random().Next();
		this.title = title;
		this.type = type;
	}
}
