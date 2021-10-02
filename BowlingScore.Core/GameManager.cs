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

			var currentFrame = this.CurrentGame.Frames.OrderBy(f => f.FrameNumber).LastOrDefault();
			if(currentFrame == null)//first frame, first Delivery
			{
				currentFrame = new Frame { FrameNumber = 1, Deliveries = new List<Delivery>() { newDelivery } };
				this.CurrentGame.Frames.Add(currentFrame);
				if(newDelivery.IsStrike)
				{
					currentFrame.IsStrike = true;
					this.CurrentGame.Frames.Add(new Frame() { FrameNumber = currentFrame.FrameNumber + 1 });
				}
				return; //First Delivery has been recorded. Nothing else to do here.
			}
			else
			{
				currentFrame.Deliveries.Add(newDelivery);
				if (newDelivery.IsStrike)
				{
					currentFrame.IsStrike = true;
					currentFrame.FrameScore = 0; //Reset the score.
					if(currentFrame.FrameNumber != 10) //Don't add an 11th frame.
						this.CurrentGame.Frames.Add(new Frame() { FrameNumber = currentFrame.FrameNumber + 1 });
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

			foreach (var frame in CurrentGame.Frames)
			{
				CalculateFrameScore(frame);
			}
		}

		private void CalculateFrameScore(Frame frame)
		{
			if(!frame.IsSpare || !frame.IsStrike)
			{
				frame.FrameScore = frame.Deliveries.Sum(d => d.PinsKnockedDown);
				return;
			}

			if(frame.IsSpare)
			{
				//Get Next Delivery and add 10 to that score
				if (frame.FrameNumber != 10)
				{
					var nextDelivery = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1)?.Deliveries?.FirstOrDefault();
					if (nextDelivery != null)
						frame.FrameScore = 10 + nextDelivery.PinsKnockedDown;
				}
				else
					throw new NotImplementedException("TODO");
				
			}

			if(frame.IsStrike)
			{
				//get next two deliveries and add 10 to those scores
				var nextDelivery = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1)?.Deliveries?.FirstOrDefault();
				if(nextDelivery != null && !nextDelivery.IsStrike)
				{
					var frameScore = 10 + nextDelivery.PinsKnockedDown;
					var secondDelivery = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1)?.Deliveries?.ElementAt(1);
					if (secondDelivery != null)
						frameScore += secondDelivery.PinsKnockedDown;
					
					frame.FrameScore = frameScore;
				}
			}
		}

		//private void CalculateFrameScore(Frame frame, int maxRecursion)
		//{
		//	//if( (frame.IsStrike || frame.IsSpare) && frame.FrameScore == 0)
		//	//{
		//	//	var nextFrame = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1);
		//	//	if (nextFrame == null)
		//	//		return;
		//	//	CalculateFrameScore(nextFrame);
		//	//}
		//	//else
		//	//{
		//	//	frame.FrameScore
		//	//}

		//	var frameScore = frame.Deliveries.Sum(fs => fs.PinsKnockedDown);
		//	if(!frame.IsStrike || !frame.IsSpare)
		//	{
		//		frame.FrameScore = frameScore;
		//	}
		//	else if(frame.IsSpare && maxRecursion <= 1) //Is a spare and hasn't been calculated yet.
		//	{
		//		var nextFrame = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1);
		//		if(nextFrame != null)
		//		{
		//			frame.FrameScore = 10;
		//			CalculateFrameScore(nextFrame, 1);

		//		}
		//	}
		//}

		
	}
}
