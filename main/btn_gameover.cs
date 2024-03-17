using Godot;
using System;

public class btn_gameover : TextureButton
{
	Node sygnal;
	bool _is_dead = false;
	public override void _Ready()
	{
		sygnal = GetNode("/root/Sygnaly");
		Connect("pressed",this,"_on_pressed");
		Hide();
		sygnal.Connect("the_king_is_dead",this,"_the_king_is_dead");
	}
	public void _on_pressed()
	{
		GetTree().Quit();
	}
	public void _the_king_is_dead(bool _is_dead)
	{
		if (_is_dead = true )
		{
			Show();
		}
	}
}
//the_king_is_dead
