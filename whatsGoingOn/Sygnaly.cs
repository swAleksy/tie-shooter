using Godot;
using System;


public class Sygnaly : Node
{
	[Signal]
	public delegate void signal_player_hp(int lives);
	
	[Signal]
	public delegate void signal_points(int pkt);
	
	[Signal]
	public delegate void the_king_is_dead(bool is_dead);
	
	[Signal]
	public delegate void score_from_game(int scr);

	[Signal]
	public delegate void final_score_to_output(int litosci);

}
