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

			gameManager.AddScoreEntryToGame(5);

			Console.ReadLine();
		}
	}
}
