using Godot;
using System;

public class pewImpactEffect : Sprite
{

	private void _on_Timer_timeout()
	{
		QueueFree();
	}
}



