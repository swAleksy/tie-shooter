using Godot;
using System;

public class bts_highestscore : TextureButton
{
	///////////////////////////NIE DZIALA/////////////////////////
	Node sygnal;
	int fileScore = 0;
	int bestScore = 0;
	string filePath = "res://save_read_file/higscr.txt";
		
	///// 
	public override void _Ready()
	{
		Connect("pressed",this,"_on_pressed");
		sygnal = GetNode("/root/Sygnaly");
		
		sygnal.Connect("score_from_game",this,"_setScore");
		sygnal.EmitSignal("final_score_to_output",bestScore);
	}
	public void _on_pressed()
	{
		GetTree().ChangeScene("res://menu/highestscore.tscn");
		sygnal.EmitSignal("final_score_to_output",bestScore);
	}
	/////
	
	public void _setScore(int points)
	{
		GD.Print("test");
		int pointsFromGame = points;
		loadScore();
		if (pointsFromGame < fileScore)
		{
			bestScore = fileScore;
			saveScore();
			GD.Print("1");
		}
		else
		{
			bestScore = pointsFromGame;
			saveScore();
			GD.Print("2");
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
	
}
