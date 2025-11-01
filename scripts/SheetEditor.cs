using Godot;
using System;
using System.Linq;
using VirtualTabletop.Types;
using System.Text.Json;

namespace VirtualTabletop.Sheets;

public partial class SheetEditor : Control
{
	[Export]
	public string FolderName = "default";


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
		var scene = (SheetCreatorPanel)GD.Load<PackedScene>("res://panel.tscn").Instantiate();
		scene.MovedUp += PanelMovedUp;
		scene.MovedDown += PanelMovedDown;
		GetNode("ScrollContainer/PanelContainer").AddChild(scene);
		scene.index = GetNode("ScrollContainer/PanelContainer").GetChildren().Count() - 1;
		RefreshPanelIndices();
	}

	public void RefreshPanelIndices() {
		int index = 0;
		foreach(Node child in GetNode("ScrollContainer/PanelContainer").GetChildren()) {
			if (child is SheetCreatorPanel PanelChild) {
				PanelChild.index = index;
				index++;
				PanelChild.arrayLength = GetNode("ScrollContainer/PanelContainer").GetChildren().Count();

			}
		}
	}
	public void PanelMovedUp(int index) {
		GD.Print(index);
		var ParentNode = GetNode("ScrollContainer/PanelContainer");
		var item = (SheetCreatorPanel)(ParentNode.GetChildren()[index]);
		ParentNode.MoveChild(item, index - 1);
		RefreshPanelIndices();
	}
	public void PanelMovedDown(int index) {
		var ParentNode = GetNode("ScrollContainer/PanelContainer");
		var item = (SheetCreatorPanel)(ParentNode.GetChildren()[index]);
		ParentNode.MoveChild(item, index + 1);
		RefreshPanelIndices();

	}
	public void ExportTemplate() {
		GD.Print("HI");
		var random = new Random();
		var template = new SheetTemplate {
			id = random.Next(),
			title = GetNode<TextEdit>("SheetTitle").Text
		};
		foreach (Node node in GetNode("ScrollContainer/PanelContainer").GetChildren()) {
			if (node is SheetCreatorPanel PanelChild) {
				Field field =
					new(PanelChild.GetNode<TextEdit>("Title").Text,
						(SheetType)PanelChild.GetNode<OptionButton>("FieldType").Selected);

				template.fields.Add(field);
			}
		}

		GD.Print(JsonSerializer.Serialize(template));

	}
}
