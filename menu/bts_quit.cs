using Godot;
using System;

public class bts_quit : TextureButton
{
	public override void _Ready()
	{
		Connect("pressed",this,"_on_pressed");
	}
	public void _on_pressed()
	{
		GetTree().Quit();
	}
}

