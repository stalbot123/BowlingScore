﻿using BowlingScore.Core;
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
			gameManager.PrintCurrentScore();

			//Game All Strikes
			var gameManager2 = new GameManager(playerName);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10); //10th frame
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.AddScoreEntryToGame(10);
			gameManager2.PrintCurrentScore();

			////Game All Gutters or Fouls
			var gameManager3 = new GameManager(playerName);
			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0); 

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);

			gameManager3.AddScoreEntryToGame(0);
			gameManager3.AddScoreEntryToGame(0);
			gameManager3.PrintCurrentScore();

			var gameManager4 = new GameManager(playerName);
			gameManager4.AddScoreEntryToGame(5);
			gameManager4.AddScoreEntryToGame(5);

			gameManager4.AddScoreEntryToGame(4);
			gameManager4.AddScoreEntryToGame(6);

			gameManager4.AddScoreEntryToGame(3);
			gameManager4.AddScoreEntryToGame(7);

			gameManager4.AddScoreEntryToGame(2);
			gameManager4.AddScoreEntryToGame(8);

			gameManager4.AddScoreEntryToGame(1);
			gameManager4.AddScoreEntryToGame(9);

			gameManager4.AddScoreEntryToGame(6);
			gameManager4.AddScoreEntryToGame(4);

			gameManager4.AddScoreEntryToGame(7);
			gameManager4.AddScoreEntryToGame(3);

			gameManager4.AddScoreEntryToGame(8);
			gameManager4.AddScoreEntryToGame(2);

			gameManager4.AddScoreEntryToGame(9);
			gameManager4.AddScoreEntryToGame(1);

			gameManager4.AddScoreEntryToGame(5);
			gameManager4.AddScoreEntryToGame(5);
			gameManager4.AddScoreEntryToGame(3); //I get entries because it was a spare.

			gameManager4.AddScoreEntryToGame(10);
			gameManager4.PrintCurrentScore();


			/////////
			var gameManager5 = new GameManager("Tester 1");
			gameManager5.AddScoreEntryToGame(1);
			gameManager5.AddScoreEntryToGame(4);
			gameManager5.AddScoreEntryToGame(4);
			gameManager5.AddScoreEntryToGame(5);
			gameManager5.AddScoreEntryToGame(6);
			gameManager5.AddScoreEntryToGame(4);
			gameManager5.AddScoreEntryToGame(5);
			gameManager5.AddScoreEntryToGame(5);
			gameManager5.AddScoreEntryToGame(10);
			gameManager5.AddScoreEntryToGame(0);
			gameManager5.AddScoreEntryToGame(1);
			gameManager5.AddScoreEntryToGame(7);
			gameManager5.AddScoreEntryToGame(3);
			gameManager5.AddScoreEntryToGame(6);
			gameManager5.AddScoreEntryToGame(4);
			gameManager5.AddScoreEntryToGame(10);
			gameManager5.AddScoreEntryToGame(2);
			gameManager5.AddScoreEntryToGame(8);
			gameManager5.AddScoreEntryToGame(6);
			gameManager5.PrintCurrentScore();

			Console.ReadLine();
		}
	}
}
