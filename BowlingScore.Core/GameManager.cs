using BowlingScore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core
{
	public class GameManager
	{
		public GameManager(string playerName)
		{
			this.CurrentGame = new Game(playerName);
		}

		protected Game CurrentGame { get; set; }

		public void AddScoreEntryToGame(int pinsKnockedDown, bool isFoul = false)
		{
			if (CurrentGame.GameOver)
				return;

			AddDeliveryToGame(pinsKnockedDown, isFoul);
			UpdateFrameScores();
		}

		private void AddDeliveryToGame(int pinsKnockedDown, bool isFoul = false)
		{
			var newDelivery = new Delivery(pinsKnockedDown, isFoul);

			var currentFrame = this.CurrentGame.Frames.OrderBy(f => f.FrameNumber).FirstOrDefault();
			if(currentFrame == null)//first frame, first Delivery
			{
				currentFrame = new Frame { FrameNumber = 1, Deliveries = new List<Delivery>() { newDelivery } };
				if(newDelivery.IsStrike)
				{
					currentFrame.IsStrike = true;
					this.CurrentGame.Frames.Add(new Frame() { FrameNumber = currentFrame.FrameNumber });
				}
				return;
			}
			else
			{
				currentFrame.Deliveries.Add(newDelivery);
				if (newDelivery.IsStrike)
				{
					currentFrame.IsStrike = true;
					currentFrame.FrameScore = 0; //Reset the score.
					this.CurrentGame.Frames.Add(new Frame() { FrameNumber = currentFrame.FrameNumber });
				}
				else if (currentFrame.IsSpare)
				{
					currentFrame.FrameScore = 0; //Reset the score.
				}
				else
				{
					currentFrame.FrameScore = currentFrame.Deliveries.Sum(d => d.PinsKnockedDown);
				}
			}

			if(currentFrame.FrameNumber == 10) //End the game
			{
				if (!currentFrame.IsStrike && !currentFrame.IsSpare && currentFrame.Deliveries.Count == 2)
					CurrentGame.GameOver = true;
				else if (currentFrame.Deliveries.Count == 3)
					CurrentGame.GameOver = true;
			}
			else
			{
				if (currentFrame.Deliveries.Count == 2)
					CurrentGame.Frames.Add(new Frame { FrameNumber = currentFrame.FrameNumber + 1 });
			}
		}

		private void UpdateFrameScores()
		{
			
			//go through the frames and calculate each score.
		}

		
	}
}
