using BowlingScore.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingScore.Tests
{
	[TestClass]
	public class BowlingTests
	{
		[TestMethod]
		public void ExampleGame_Success()
		{
			var gameManager = new GameManager("Tester 1");
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

			Assert.IsTrue(gameManager.GameIsOver());
			Assert.AreEqual(180, gameManager.FinalScore());
		}

		[TestMethod]
		public void UnfinishedGame_Success()
		{
			var gameManager = new GameManager("Tester 1");
			//Game 1: Strike, Strike, Strike, 7, 2, 8, 2(spare), F, 9, Strike, 7, 3(spare), 9, 0, strike, strike, 8
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(7);
			gameManager.AddScoreEntryToGame(2);
			gameManager.AddScoreEntryToGame(8);
			gameManager.AddScoreEntryToGame(2);
			gameManager.AddScoreEntryToGame(0); //foul

			Assert.IsFalse(gameManager.GameIsOver());
			Assert.AreEqual(95, gameManager.FinalScore());
		}

		[TestMethod]
		public void MixedGame_Success()
		{
			var gameManager = new GameManager("Tester 1");
			gameManager.AddScoreEntryToGame(1);
			gameManager.AddScoreEntryToGame(4);
			gameManager.AddScoreEntryToGame(4);
			gameManager.AddScoreEntryToGame(5);
			gameManager.AddScoreEntryToGame(6);
			gameManager.AddScoreEntryToGame(4);
			gameManager.AddScoreEntryToGame(5);
			gameManager.AddScoreEntryToGame(5);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(0);
			gameManager.AddScoreEntryToGame(1);
			gameManager.AddScoreEntryToGame(7);
			gameManager.AddScoreEntryToGame(3);
			gameManager.AddScoreEntryToGame(6);
			gameManager.AddScoreEntryToGame(4);
			gameManager.AddScoreEntryToGame(10);
			gameManager.AddScoreEntryToGame(2);
			gameManager.AddScoreEntryToGame(8);
			gameManager.AddScoreEntryToGame(6);

			Assert.IsTrue(gameManager.GameIsOver());
			Assert.AreEqual(133, gameManager.FinalScore());
		}
	}
}
