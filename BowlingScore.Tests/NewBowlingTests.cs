using BowlingScore.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Tests
{
	[TestClass]
	public class NewBowlingTests
	{
		[TestMethod]
		public void ExampleGame_Success()
		{
			var gameManager = new NewGameManager();
			//Game 1: Strike, Strike, Strike, 7, 2, 8, 2(spare), F, 9, Strike, 7, 3(spare), 9, 0, strike, strike, 8
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(0); //foul
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(3);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(8);
			gameManager.GetCurrentScore();

			gameManager.GetCurrentScore();
			Assert.AreEqual(180, gameManager.GetCurrentScore());
		}

		[TestMethod]
		public void UnfinishedGame_Success()
		{
			var gameManager = new NewGameManager();
			//Game 1: Strike, Strike, Strike, 7, 2, 8, 2(spare), F, 9, Strike, 7, 3(spare), 9, 0, strike, strike, 8
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(0); //foul

			Assert.AreEqual(95, gameManager.GetCurrentScore());
		}

		[TestMethod]
		public void MixedGame_Success()
		{
			var gameManager = new NewGameManager();
			gameManager.AddDeliveryToGame(1);
			gameManager.AddDeliveryToGame(4);
			gameManager.AddDeliveryToGame(4);
			gameManager.AddDeliveryToGame(5);
			gameManager.AddDeliveryToGame(6);
			gameManager.AddDeliveryToGame(4);
			gameManager.AddDeliveryToGame(5);
			gameManager.AddDeliveryToGame(5);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(1);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(3);
			gameManager.AddDeliveryToGame(6);
			gameManager.AddDeliveryToGame(4);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(6);

			var currentScore = gameManager.GetCurrentScore();

			Assert.AreEqual(133, gameManager.GetCurrentScore());
		}

		[TestMethod]
		public void JohnDoe1_Success()
		{
			var gameManager = new NewGameManager();
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(4);
			gameManager.AddDeliveryToGame(4);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(3);
			gameManager.AddDeliveryToGame(5);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(1);
			gameManager.AddDeliveryToGame(7);

			var currentScore = gameManager.GetCurrentScore();

			Assert.AreEqual(133, gameManager.GetCurrentScore());
		}

		[TestMethod]
		public void JohnDoe2_Success()
		{
			var gameManager = new NewGameManager();
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(5);
			gameManager.AddDeliveryToGame(3);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(1);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(1);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(5);
			gameManager.AddDeliveryToGame(1);
			gameManager.AddDeliveryToGame(3);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(0);

			var currentScore = gameManager.GetCurrentScore();

			Assert.AreEqual(122, gameManager.GetCurrentScore());
		}

		[TestMethod]
		public void JohnDoe3_Success()
		{
			var gameManager = new NewGameManager();
			gameManager.AddDeliveryToGame(6);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(7);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(3);
			gameManager.AddDeliveryToGame(4);
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(9);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(6);
			gameManager.AddDeliveryToGame(3);
			gameManager.AddDeliveryToGame(8);
			gameManager.AddDeliveryToGame(2);
			gameManager.AddDeliveryToGame(7);

			var currentScore = gameManager.GetCurrentScore();

			Assert.AreEqual(153, gameManager.GetCurrentScore());
		}

		[TestMethod]
		public void AllStrikes_Success()
		{
			var gameManager = new NewGameManager();
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);
			gameManager.AddDeliveryToGame(10);

			var currentScore = gameManager.GetCurrentScore();

			Assert.AreEqual(300, gameManager.GetCurrentScore());
		}

		[TestMethod]
		public void AllGutters_Success()
		{
			var gameManager = new NewGameManager();
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);
			gameManager.AddDeliveryToGame(0);

			var currentScore = gameManager.GetCurrentScore();

			Assert.AreEqual(0, gameManager.GetCurrentScore());
		}
	}
}
