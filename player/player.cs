using Godot;
using System;



public class player : Area2D
{
		Vector2 velocity = new Vector2(0,0);
		PackedScene plPew_pew = (PackedScene)ResourceLoader.Load("res://pew_pew/pew_pew.tscn");
		Node2D pew_pewPozycja;
		Timer pew_pewOpoznienie;
		Timer spawnShield;
		Sprite shield;
		Node sygnal;
		float speed = 300;
		float pewOpozninie = 0.1F;
		float spawnShieldTime = 2F;
		public int lives = 3;
		
	public override void _Ready()
	{	
		sygnal = GetNode("/root/Sygnaly");
		pew_pewPozycja = GetNode<Node2D>("pew_pewPozycja");
		pew_pewOpoznienie = GetNode<Timer>("pew_pewOpoznienie");
		spawnShield = GetNode<Timer>("spawnShield");
		shield = GetNode<Sprite>("shield");
		
		sygnal.EmitSignal("signal_player_hp",lives);
		shield.Visible = false;
	}
	
	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("shoot") && (pew_pewOpoznienie.IsStopped()))
		{
			pew_pewOpoznienie.Start(pewOpozninie);
			foreach (Node2D child in pew_pewPozycja.GetChildren())
			{
				pew_pew pew = (pew_pew)plPew_pew.Instance();
				pew.GlobalPosition = child.GlobalPosition;
				GetTree().CurrentScene.AddChild(pew);
			}
		}
	}
	
	public void damage(int dmg)
	{
	
		if (spawnShield.IsStopped() == false)
		{return;}

		spawnShield.Start(spawnShieldTime);
		shield.Visible = true;
		lives -= dmg;
		
		sygnal.EmitSignal("signal_player_hp",lives);

		if (lives <= 0 )
		{
			Console.WriteLine("zdechl");
			QueueFree();
			sygnal.EmitSignal("the_king_is_dead",true);
		}
	
	}
	
	public override void _PhysicsProcess(float delta)
	{
		Vector2 dirVec = new Vector2(0,0);
		var wymiaryViewPortu = GetViewportRect().Size;
		
		if (Input.IsActionPressed("move_up"))
		{
			dirVec.y = -1;
		}
		else if (Input.IsActionPressed("move_down"))
		{
			dirVec.y = 1;
		}
		if (Input.IsActionPressed("move_left"))
		{
			dirVec.x = -1;
		}
		else if (Input.IsActionPressed("move_right"))
		{
			dirVec.x = 1;
		}
		
		if (Position.x > wymiaryViewPortu.x )
		{
			dirVec.x = -1;
		}
		if (Position.x < 0)
		{
			dirVec.x = 1;
		}
		if (Position.y > wymiaryViewPortu.y )
		{
			dirVec.y = -1;
		}
		if (Position.y < 0)
		{
			dirVec.y = 1;
		}
		
		velocity = dirVec.Normalized() * speed;
		Position += velocity * delta;
	}
	public void _on_spawnShield_timeout()
	{
		shield.Visible = false;
	}
}
