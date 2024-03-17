using Godot;
using System;

public class EnemyTwoShooter : Enemy
{
	Node2D GunsPosition;
	Timer FireDelay;
	PackedScene plPew = (PackedScene)ResourceLoader.Load("res://pew_pew/EnemyPew.tscn");
	float fireRate = 0.6F;
	public override void _Ready()
	{
		GunsPosition = GetNode<Node2D>("GunsPosition");
		FireDelay = GetNode<Timer>("FireDelay");
	}
	public override void _Process(float delta)
	{
		if (FireDelay.IsStopped())
		{
			fire();
			FireDelay.Start(fireRate);
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
