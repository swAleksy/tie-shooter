using Godot;
using System;

public class EnemyPew : Area2D
{
	float speed = 500;
	PackedScene plPewImpactEffect = (PackedScene)ResourceLoader.Load("res://pew_pew/EnemyPewImpactEffect.tscn");
	
	public override void _PhysicsProcess(float delta)
	{
		Vector2 pewpew_vector = new Vector2(0,speed * delta);
		pewpew_vector += Position ;
		SetGlobalPosition(pewpew_vector);
	}
	
	private void _on_pew_pew_area_entered(object area)
	{
		if (area is player)
		{
			player player_ = (player)area;
			Sprite pewEffect = (Sprite)plPewImpactEffect.Instance();
			pewEffect.Position = Position;
			GetTree().CurrentScene.AddChild(pewEffect);

			player_.damage(1);
			Console.WriteLine("hit");
			QueueFree();
		}	
	}

	public void _on_VisibilityNotifier2D_screen_exited()
	{
		QueueFree();
	}	
}
