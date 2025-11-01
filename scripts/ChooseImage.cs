using Godot;
using System;
using System.IO;
using System.Net.Mail;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

public partial class ChooseImage : OptionButton
{
	[Signal]
	delegate void sendChosenEventHandler(int choice);

	
	[Export]
	public string chosenBackground;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void pickBackground(int index)
	{
		int choice = index;
		EmitSignal(SignalName.sendChosen, choice);
		this.Hide();

		

		
	} 

}
