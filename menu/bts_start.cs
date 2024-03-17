using Godot;
using System;

public class bts_start : TextureButton
{

	public override void _Ready()
	{
		Connect("pressed",this,"_on_pressed");
	}
	public void _on_pressed()
	{
		GetTree().ChangeScene("res://main/gameplay.tscn");
	}
}
