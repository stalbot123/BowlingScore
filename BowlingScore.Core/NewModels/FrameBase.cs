using BowlingScore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.NewModels
{
	public class FrameBase : IFrameType
	{
		public int FrameNumber { get; set; }
		public ICollection<IDeliveryType> Deliveries { get; set; }
		public int FrameScore { get; set; }


		public FrameBase()
		{
			Deliveries = new HashSet<IDeliveryType>();
		}
	}
}
