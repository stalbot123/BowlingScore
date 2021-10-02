using BowlingScore.Core;
using System;

namespace BowlingScore.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the Player Name:");

			var playerName = Console.ReadLine();

			var gameManager = new GameManager(playerName);

			//Game 1: Strike, Strike, Strike, 7, 2, 8, 2(spare), F, 9, Strike, 7, 3(spare), 9, 0, strike, strike, 8
			gameManager.AddScoreEntryToGame(10);
			//gameManager.DisplayCurrentScore();
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(7);
			gameManager.AddScoreEntryToGame(2);
			gameManager.AddScoreEntryToGame(8);
			gameManager.AddScoreEntryToGame(2);
			gameManager.AddScoreEntryToGame(0); //foul
			gameManager.AddScoreEntryToGame(9);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(7);
			gameManager.AddScoreEntryToGame(3);
			gameManager.AddScoreEntryToGame(9);
			gameManager.AddScoreEntryToGame(0);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(8);



			Console.ReadLine();
		}
	}
}
