using Godot;
using System;

public class HUD : Control
{
	PackedScene PlLifeIcon = (PackedScene)ResourceLoader.Load("res://HUD/LifeIcon.tscn");
	HBoxContainer IconContainer;
	Label points_label;
	Node sygnal;
	Node sygnal2;
	int points = 0;

	
	public override void _Ready()
	{
		sygnal = GetNode("/root/Sygnaly");
		IconContainer = GetNode<HBoxContainer>("IconContainer"); 
		points_label = GetNode<Label>("points");
		sygnal.Connect("signal_player_hp",this,"_signal_player_hp");
		sygnal.Connect("signal_points",this,"_Tsignal_points");
		sygnal.Connect("the_king_is_dead",this,"_send_score");
	}

	private void clearLives()
	{
		foreach (TextureRect ikona in IconContainer.GetChildren())
		{
			IconContainer.RemoveChild(ikona);
			ikona.QueueFree();
		}
	}
	
	private void setlLives(int lives)
	{
		clearLives();
		for (int i = 0; i < lives; i++ )
		{
			IconContainer.AddChild(PlLifeIcon.Instance());
		}
	}
		private void _signal_player_hp(int lives)
	{
		setlLives(lives);
	}

		private void _Tsignal_points(int pkt)
	{
		points += pkt;
		points_label.Text = points.ToString();
	}
	///////////////////////////USELESS/////////////////////////
		private void _send_score(int pkt)
	{
		
		sygnal.EmitSignal("score_from_game",points);
	}

 	public override void _Process(float delta)
	 {
		
		
	 }
}
