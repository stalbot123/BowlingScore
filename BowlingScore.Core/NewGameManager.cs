using BowlingScore.Core.Factories;
using BowlingScore.Core.Interfaces;
using BowlingScore.Core.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core
{
	public class NewGameManager
	{
		protected Game CurrentGame;

		public NewGameManager()
		{
			this.CurrentGame = new Game();
		}

		public void AddDeliveryToGame(int pinsKnockedDown)
		{
			var lastDelivery = CurrentGame.AllDeliveries.LastOrDefault();
			var latestDelivery = DeliveryFactory.CreateDeliveryType(pinsKnockedDown, lastDelivery as StandardDelivery);
			CurrentGame.AllDeliveries.Add(latestDelivery);

			AssignDeliveryFrame(latestDelivery);
		}

		public void GetCurrentScore()
		{
			ScoreFrames();

			Console.WriteLine("here");
		}

		private void AssignDeliveryFrame(IDeliveryType newDelivery)
		{
			var lastFrame = CurrentGame.Frames.LastOrDefault();
			var newFrame = FrameFactory.CreateFrame(newDelivery, lastFrame);
			CurrentGame.Frames.Add(newFrame);
		}

		private void ScoreFrames()
		{
			//TODO
		}
	}
}
