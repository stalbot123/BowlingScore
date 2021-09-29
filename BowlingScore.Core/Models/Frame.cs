using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Models
{
	public class Frame
	{
		public int FrameNumber { get; set; }
		public Delivery[] Deliveries { get; set; } = new Delivery[2];
		public Delivery FinalDelivery { get; set; }
		public int FrameScore { get; set; }
	}
}
