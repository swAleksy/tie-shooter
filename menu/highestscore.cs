using Godot;
using System;

public class highestscore : Node
{	/////////////NIE DZIALA///////////////////
	Node sygnal;
	Label HScore_label;
	public override void _Ready()
	{
		HScore_label = GetNode<Label>("CanvasLayer/HighScoreLabel");
		sygnal = GetNode("/root/Sygnaly");
		sygnal.Connect("final_score_to_output",this,"_2053wypuscciemnie");
	}

	public void _2053wypuscciemnie(int hScore)
	{
		GD.Print("testXd");
		HScore_label.Text = hScore.ToString();
	}

}
