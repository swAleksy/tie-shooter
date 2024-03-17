using Godot;
using System;
using System.Collections.Generic;

public class Spawner : Node2D
{
	List<PackedScene> preLoadedEnemies = new List<PackedScene> 
	{
	(PackedScene)ResourceLoader.Load("res://enemy/EnemyOne.tscn"),
	(PackedScene)ResourceLoader.Load("res://enemy/EnemyTwoShooter.tscn"),
	(PackedScene)ResourceLoader.Load("res://enemy/EnemyShooterThree.tscn")
	};
	
	PackedScene plMeteor = (PackedScene)ResourceLoader.Load("res://meteor/Meteor.tscn");
	
	Timer SpawnTimer;

	float spawnDelay = 2;
	public override void _Ready()
	{
		GD.Randomize();
		SpawnTimer = GetNode<Timer>("SpawnTimer");
		SpawnTimer.Start(spawnDelay);
	}
	private void _on_SpawnTimer_timeout()
	{
		var vievPortSize = GetViewportRect();
		double xPosition = GD.RandRange(20 ,vievPortSize.End.x - 20);
		if (GD.Randf() < 0.2 )
		{
			Meteor meteor = (Meteor)plMeteor.Instance();
			Vector2 spawningEnemyPosition = new Vector2((float)xPosition,Position.y);
			meteor.Position = spawningEnemyPosition;
			GetTree().CurrentScene.AddChild(meteor);
		}
		else
		{
			PackedScene enemyPreload = preLoadedEnemies[(int)GD.RandRange(0,3)];
			Enemy spawningEnemy = (Enemy)enemyPreload.Instance();
			//spawningEnemy.Position = Vector2(0,0);
			Vector2 spawningEnemyPosition = new Vector2((float)xPosition,Position.y);
			spawningEnemy.Position = spawningEnemyPosition;
			GetTree().CurrentScene.AddChild(spawningEnemy);
		}
		if (spawnDelay <= 1.5)
		{SpawnTimer.Start(spawnDelay);}
		else
		{
			spawnDelay -= 0.1F;
			SpawnTimer.Start(spawnDelay);
		}
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}




