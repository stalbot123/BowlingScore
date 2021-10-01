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
		//public Delivery[] Deliveries { get; set; } = new Delivery[2];
		public ICollection<Delivery> Deliveries { get; set; }
		//public Delivery FinalDelivery { get; set; }
		public int FrameScore { get; set; }

		public bool IsStrike { get; set; }
		//public bool IsSpare { get; set; }
		public bool IsSpare
		{
			get
			{
				if (this.Deliveries.Count == 2 && this.Deliveries.Sum(d => d.PinsKnockedDown) == 10)
					return true;
				else
					return false;
			}
		}

		public Frame()
		{
			Deliveries = new HashSet<Delivery>();
		}
	}
}
