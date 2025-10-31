using Godot;
using System;
using System.Text.Json;
using System.Collections.Generic;
namespace VirtualTabletop.Types;


public partial class CharacterSheet : Node
{
	public override void _Ready() {
		SheetTemplate test = new SheetTemplate();
		test.fields.Add(new Field("aw",SheetType.TypeString));
		test.fields.Add(new Field("yeah",SheetType.TypeInt));
		GD.Print(JsonSerializer.Serialize(test));
	}
}

public enum SheetType {
    TypeInt,
    TypeFloat,
    TypeString,
    TypeBool,
    TypeDepletable,
}

public class SheetTemplate {
	public int id {get; set;}

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
