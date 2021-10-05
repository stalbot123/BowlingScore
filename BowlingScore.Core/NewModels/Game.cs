using BowlingScore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.NewModels
{
	public class Game
	{
		public ICollection<IDeliveryType> AllDeliveries{ get; set; }
		public ICollection<IFrameType> Frames { get; set; }

		public Game()
		{
			AllDeliveries = new HashSet<IDeliveryType>();
			Frames = new HashSet<IFrameType>();
		}
	}
}
