using Godot;
using System;
using System.Text.Json;
using System.Collections.Generic;
namespace VirtualTabletop.Types;


public partial class CharacterSheet : Node
{
	[Export]
	string FileName;
	public override void _Ready() {
		SheetTemplate test = new SheetTemplate();
		test.fields.Add(new Field("aw",SheetType.TypeString));
		test.fields.Add(new Field("yeah",SheetType.TypeInt));
		GD.Print(JsonSerializer.Serialize(test));
		UpdateSheet();
	}

	public void UpdateSheet() {
		GD.Print("Now Deserializing");
		foreach ( Node child in this.GetChildren() ) {
			child.QueueFree();
		}

		using var file = FileAccess.Open(FileName, FileAccess.ModeFlags.Read);
		string content = file.GetAsText();
		SheetTemplate template = JsonSerializer.Deserialize<SheetTemplate>(content);
		foreach (Field i in template.fields) {
			GD.Print(i.title);
			GD.Print(i.type);
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
