using Godot;
using System;

public class pew_pew : Area2D
{
	float speed = 500;
	PackedScene plPewImpactEffect = (PackedScene)ResourceLoader.Load("res://pew_pew/pewImpactEffect.tscn");
	
	public override void _PhysicsProcess(float delta)
	{
		Vector2 pewpew_vector = new Vector2(0,-speed * delta);
		pewpew_vector += Position ;
		SetGlobalPosition(pewpew_vector);
	}
	
	private void _on_pew_pew_area_entered(object area)
	{
		if (area is Meteor)
		{
			Meteor meteor_ = (Meteor)area;
			Sprite pewEffect = (Sprite)plPewImpactEffect.Instance();
			pewEffect.Position = Position;
			GetTree().CurrentScene.AddChild(pewEffect);

			meteor_.damage(1);
			Console.WriteLine("hitE");
			QueueFree();
		}	
		else if (area is Enemy) 
		{
			Enemy enemy_ = (Enemy)area;
			Sprite pewEffect = (Sprite)plPewImpactEffect.Instance();
			pewEffect.Position = Position;
			GetTree().CurrentScene.AddChild(pewEffect);

			enemy_.damage(1);
			Console.WriteLine("hitE");
			QueueFree();
		}
	}

	public void _on_VisibilityNotifier2D_screen_exited()
	{
		QueueFree();
	}	
}





