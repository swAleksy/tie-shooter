using Godot;
using System;

public class btn_quitHighScore : TextureButton
{
	public override void _Ready()
	{
		Connect("pressed",this,"_on_pressed");
	}
	public void _on_pressed()
	{
		GetTree().ChangeScene("res://menu/menu.tscn");
	}
}
