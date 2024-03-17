using Godot;
using System;

public class Meteor : Area2D
{
	float speed = 0;
	float rotationSpeed = 0;
	public int hp = 20;
	PackedScene meteorParticles = (PackedScene)ResourceLoader.Load("res://meteor/MeteorParticles.tscn");	
	player playerInArea = null;
	Random rnd = new Random();
	Node sygnal;
	Node sygnal2;
	
	public override void _Ready()
	{
		sygnal2 = GetNode("/root/Sygnaly2");
		sygnal = GetNode("/root/Sygnaly");
		speed = rnd.Next(9,40);
		Console.WriteLine(speed);
		rotationSpeed = rnd.Next(-5,5);
		Console.WriteLine(rotationSpeed);
	}
	
	public void damage(int dmg)
	{
		hp -= dmg;
		CPUParticles2D meteorFragments = (CPUParticles2D)meteorParticles.Instance();
		meteorFragments.Position = Position;
		GetTree().CurrentScene.AddChild(meteorFragments);
		
		if (hp <= 0)
		{
			QueueFree();
			sygnal.EmitSignal("signal_points", 1);
			
		}  
	}
	

	
	public override void _Process(float delta)
	{
		if (playerInArea != null)
		{playerInArea.damage(1);}
	}

	public override void _PhysicsProcess(float delta)
	{
		Vector2 meteorVector = new Vector2(0,speed * delta);
		meteorVector += Position ;
		SetGlobalPosition(meteorVector);

		Vector3 meteorRotationVector = new Vector3(0,0,rotationSpeed * delta);
		meteorRotationVector.z += Rotation;
		SetGlobalRotation(meteorRotationVector.z);
	}

	private void _on_VisibilityNotifier2D_screen_exited()
	{
		QueueFree();
	}
	
	private void _on_Meteor_area_entered(object area)
	{	
		if (area is player)
		{
			player player_ = (player)area;
			playerInArea = player_;
			Console.WriteLine("asasd al bashir");
			player_.damage(1);
		}
	}
	private void _on_Meteor_area_exited(object area)
	{
		playerInArea = null;
	}
}









