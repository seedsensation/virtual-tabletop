using Godot;
using System;
using System.Text.Json;
using System.Collections.Generic;
namespace VirtualTabletop.Types;


public partial class CharacterSheet : Node
{
	public override void _Ready() {
		SheetTemplate test = new SheetTemplate();
		test.fields.Add(new Field("aw","beans"));
		test.fields.Add(new Field("yeah",1));
		GD.Print(JsonSerializer.Serialize(test));
	}
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
	public string title {get; set;}
	public object data {get; set;}

	public Field(string title, object data) {
		this.id = new Random().Next();
		this.title = title;
		this.data = data;
	}
}
