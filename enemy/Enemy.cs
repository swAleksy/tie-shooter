using Godot;
using System;

public class Enemy : Area2D
{	
	Node sygnal;

	[Export]
	private float speed = 200;
	[Export]
	private float hp = 20; 


	player playerInArea = null;
	
	public override void _Ready()
	{	

		if (playerInArea != null)
		{playerInArea.damage(1);}
		sygnal = GetNode("/root/Sygnaly");
	}

	public override void _PhysicsProcess(float delta)
	{
		Vector2 enemy = new Vector2(0,speed * delta);
		enemy += Position ;
		SetGlobalPosition(enemy);
	}

	public void damage(int dmg)
	{
		hp -= dmg;
		if (hp <= 0)
		{	
			sygnal = GetNode("/root/Sygnaly"); // trolldespair idz pan wchuj 
			sygnal.EmitSignal("signal_points", 1);
			QueueFree();
		}  
	}
	

	private void _on_VisibilityNotifier2D_screen_exited()
	{
		QueueFree();
	}
	private void _on_Enemy_area_entered(object area)
	{
		if (area is player)
		{
			player player_ = (player)area;
			playerInArea = player_;
			player_.damage(1);
		}
	
	}
	private void _on_Enemy_area_exited(object area)
	{
		playerInArea = null;
	}
}







