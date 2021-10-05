using BowlingScore.Core.Interfaces;
using BowlingScore.Core.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Factories
{
	public static class FrameFactory
	{
		public static IFrameType CreateFrame(IDeliveryType newDelivery, IFrameType lastFrame = null)
		{
			if(lastFrame == null) //very first frame.
			{
				var result = new StandardFrame();
				result.FrameNumber = 1;
				result.Deliveries.Add(newDelivery);
				return result;
			}
			else if(lastFrame.FrameNumber < 10)
			{
				if(lastFrame.Deliveries.Count == 2) //Frame is full, create new frame.
				{
					if (lastFrame.FrameNumber != 9)
					{
						var result = new StandardFrame();
						result.FrameNumber = lastFrame.FrameNumber + 1;
						result.Deliveries.Add(newDelivery);
						return result;
					}
					else
					{
						var result = new FinalFrame();
						result.FrameNumber = 10;
						result.Deliveries.Add(newDelivery);
						return result;
					}
				}

				if (lastFrame.Deliveries.Any(d => d.GetType() == typeof(StrikeDelivery))) //Last frame was strike, create next frame.
				{
					var result = new StandardFrame();
					result.FrameNumber = lastFrame.FrameNumber + 1;
					result.Deliveries.Add(newDelivery);
					return result;
				}
				else
				{
					lastFrame.Deliveries.Add(newDelivery);
					return lastFrame;
				}
			}
			else //10th Frame
			{
				if(lastFrame.Deliveries.Count == 2 && lastFrame.Deliveries.All(d => d.GetType() == typeof(StandardDelivery)))
				{
					return lastFrame;//Game over
				}
				else if(lastFrame.Deliveries.Count == 3)
				{
					return lastFrame; //Game over
				}
				else
				{
					lastFrame.Deliveries.Add(newDelivery);
					return lastFrame;
				}
			}
		}
	}
}
