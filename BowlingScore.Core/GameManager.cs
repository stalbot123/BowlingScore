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
			{
				Console.WriteLine("Game is over. No new scores can be added");
				return;
			}

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

			foreach (var frame in CurrentGame.Frames.Where(f => f.Deliveries.Count > 0).OrderBy(f => f.FrameNumber))
			{
				CalculateFrameScore(frame);
			}
		}

		private void CalculateFrameScore(Frame frame)
		{
			if(!frame.IsSpare && !frame.IsStrike) //Regular Frame, just add the two deliveries together.
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
				{
					//Doesn't happen since USBC Rule 3a Requires both first and second ball counts be recorded unless a strike is bowled.
				}
				
			}

			if(frame.IsStrike)
			{
				//get next two deliveries and add 10 to those scores
				Delivery nextDelivery;
				if (frame.FrameNumber == 10 && frame.Deliveries.Count > 1)
					nextDelivery = frame.Deliveries.ElementAt(1);
				else
					nextDelivery = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1)?.Deliveries?.FirstOrDefault();
				
				if(nextDelivery != null)
				{
					var frameScore = 10 + nextDelivery.PinsKnockedDown;
					if(nextDelivery.IsStrike)
					{
						if(frame.FrameNumber != 10)
						{
							if(frame.FrameNumber == 9)
							{
								var secondDeliveryNextFrame = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == 10)?.Deliveries?.FirstOrDefault();
								if (secondDeliveryNextFrame != null)
									frameScore += secondDeliveryNextFrame.PinsKnockedDown;
							}
							else
							{
								var secondDeliveryNextFrame = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 2)?.Deliveries?.FirstOrDefault();
								if (secondDeliveryNextFrame != null)
								{
									frameScore += secondDeliveryNextFrame.PinsKnockedDown;
								}
							}
							
						}
						else
						{
							//why am I going to the next frame when the frame number is 10?
							//var secondDelivery = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 2)?.Deliveries?.ElementAt(1);
							//if (secondDelivery != null)
							//	frameScore += secondDelivery.PinsKnockedDown;
							var secondDelivery = frame.Deliveries.LastOrDefault();
							if (secondDelivery != null)
								frameScore += secondDelivery.PinsKnockedDown;
						}
						
					}
					else
					{
						var nextFrameDeliveries = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1)?.Deliveries;
						if(nextFrameDeliveries != null && nextFrameDeliveries.Count > 1)
							frameScore += nextFrameDeliveries.ElementAt(1).PinsKnockedDown;
						//var secondDelivery = CurrentGame.Frames.FirstOrDefault(f => f.FrameNumber == frame.FrameNumber + 1)?.Deliveries?.ElementAt(1);
						//if (secondDelivery != null)
						//	frameScore += secondDelivery.PinsKnockedDown;
					}

					frame.FrameScore = frameScore;
				}
				
			}
		}


		public void PrintCurrentScore()
		{
			foreach (var frame in CurrentGame.Frames)
			{
				//var result = $"Frame: {frame.FrameNumber} Score: {frame.FrameScore}\tRunning Total Score: {CurrentGame.ScoreRunningTotal}";
				var runningFrameTotal = CurrentGame.Frames.Where(f => f.FrameNumber <= frame.FrameNumber).Sum(f => f.FrameScore);
				var result = $"Frame: {frame.FrameNumber}\tFrame Points: {frame.FrameScore}\tActual Score: {runningFrameTotal}";
				Console.WriteLine(result);
			}
		}
		
	}
}
