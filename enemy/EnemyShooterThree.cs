using Godot;
using System;

public class EnemyShooterThree : Enemy
{
	Node2D GunsPosition;
	Timer GunDelay;
	PackedScene plPew = (PackedScene)ResourceLoader.Load("res://pew_pew/EnemyPew.tscn");
	float fireRate = 2.0F;
	public override void _Ready()
	{
		GunsPosition = GetNode<Node2D>("GunsPosition");
		GunDelay = GetNode<Timer>("GunDelay");
	}
	public override void _Process(float delta)
	{
		if (GunDelay.IsStopped())
		{
			fire();
			GunDelay.Start(fireRate);
		}
	}
	
		public void fire()
	{
		foreach (Node2D child in GunsPosition.GetChildren())
		{
			EnemyPew pew = (EnemyPew)plPew.Instance();
			pew.GlobalPosition = child.GlobalPosition;
			GetTree().CurrentScene.AddChild(pew);
		}
		
	}
}
