using Godot;
using System;

public class SideToSideShooter : EnemyTwoShooter
{
	///////////////////////////NIE DZIALA/////////////////////////
	[Export]
	float XAxisSpeed = 50;
	int XaxisDirection = 1;
	public override void _Ready()
	{
		
	}
	public override void _PhysicsProcess(float delta)
	{
		Vector2 SideToSideVector = new Vector2(0,XAxisSpeed * XaxisDirection * delta);
		SideToSideVector += Position ;
		SetGlobalPosition(SideToSideVector);

	}

}
