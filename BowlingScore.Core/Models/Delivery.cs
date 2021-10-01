using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Models
{
	public class Delivery
	{
		//public bool IsStrike { get; set; }
		public int PinsKnockedDown { get; set; }
		public bool IsFoul { get; set; }

		public bool IsStrike
		{
			get
			{
				return PinsKnockedDown == 10 ? true : false;
			}
		}

		public Delivery(int pinsKnockedDown, bool isFoul)
		{
			PinsKnockedDown = pinsKnockedDown;
		}
	}
}
