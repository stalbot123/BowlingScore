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
			var currentId = lastDelivery == null ? 1 : lastDelivery.DeliveryId + 1;
			var latestDelivery = DeliveryFactory.CreateDeliveryType(currentId, pinsKnockedDown, lastDelivery as StandardDelivery);
			CurrentGame.AllDeliveries.Add(latestDelivery);

			AssignDeliveryFrame(latestDelivery);
		}

		public int GetCurrentScore()
		{
			ScoreFrames();

			int runningTotal = 0;
			foreach (var frame in CurrentGame.Frames)
			{
				runningTotal += frame.FrameScore;
				Console.WriteLine($"Frame: {frame.FrameNumber}\tFrame Score: {frame.FrameScore}\tCurrent Total:{runningTotal}");
			}

			return runningTotal;
		}

		private void AssignDeliveryFrame(IDeliveryType newDelivery)
		{
			var lastFrame = CurrentGame.Frames.LastOrDefault();
			var newFrame = FrameFactory.CreateFrame(newDelivery, lastFrame);
			CurrentGame.Frames.Add(newFrame);
		}

		private void ScoreFrames()
		{
			//Walk through each frame and give it a score.
			foreach (var frame in CurrentGame.Frames)
			{
				if(frame.Deliveries.All(d => d.GetType() == typeof(StandardDelivery)))
				{
					frame.FrameScore = frame.Deliveries.Sum(d => d.PinsKnockedDown);
				}
				else if(frame.Deliveries.Any(d => d.GetType() == typeof(SpareDelivery)))
				{
					if(frame.FrameNumber == 10)
					{
						frame.FrameScore = frame.Deliveries.Sum(d => d.PinsKnockedDown);
					}
					else
					{
						var frameScore = 10;
						var lastDeliveryId = frame.Deliveries.Last().DeliveryId;
						var nextDelivery = CurrentGame.AllDeliveries.FirstOrDefault(ad => ad.DeliveryId == lastDeliveryId + 1);
						if (nextDelivery != null)
							frameScore += nextDelivery.PinsKnockedDown;
						frame.FrameScore = frameScore;
					}
					
				}
				else if(frame.Deliveries.Any(d => d.GetType() == typeof(StrikeDelivery)))
				{
					var frameScore = 10;
					var lastDeliveryId = frame.Deliveries.First().DeliveryId; //this is the strike delivery
					var nextDelivery = CurrentGame.AllDeliveries.FirstOrDefault(ad => ad.DeliveryId == lastDeliveryId+ 1);
					if (nextDelivery != null)
						frameScore += nextDelivery.PinsKnockedDown;
					var secondDelivery = CurrentGame.AllDeliveries.FirstOrDefault(ad => ad.DeliveryId == lastDeliveryId + 2);
					if (secondDelivery != null)
						frameScore += secondDelivery.PinsKnockedDown;
					frame.FrameScore = frameScore;
				}
			}
		}
	}
}
