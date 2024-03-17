using Godot;
using System;

public class HigheStscoreSave : Node
{
	///////////////////////////NIE DZIALA/////////////////////////
	/*
	Node sygnal;
	int fileScore = 0;
	int bestScore = 0;
	string filePath = "res://save_read_file/higscr.txt";
	
	public override void _Ready()
	{

		sygnal = GetNode("/root/Sygnaly");
		sygnal.Connect("the_king_is_dead",this,"_setScore");
	}

	public void _setScore(int scr)
	{
		int pointsFromGame = scr;
		loadScore();
		if (scr < fileScore)
		{
			bestScore = fileScore
			sygnal.EmitSignal("final_score_to_output",bestScore);
		}
		else
		{
			bestScore = scr;
			saveScore();
		}
	}

	public void saveScore()
	{
		File file = new File();
		file.Open(filePath,File.ModeFlags.Write);
		file.StoreLine((bestScore.ToString()));
		file.Close();
	}
	public void loadScore()
	{
		File file = new File();
		if(file.FileExists(filePath))
		{
			file.Open(filePath,File.ModeFlags.Read);
			fileScore = file.GetLine().ToInt();
			file.Close();
		 	
		}
		else {return;}
	}

	public void clean()
	{
		File file = new File();
		file.Open(filePath,File.ModeFlags.Write);
		file.StoreLine("0");
		file.Close();
	}
	public void sendScore()
	{
		sygnal.EmitSignal("final_score_to_output",bestScore);
	}

*/
}
