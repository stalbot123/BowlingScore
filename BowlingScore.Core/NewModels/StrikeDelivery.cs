using BowlingScore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.NewModels
{
	public class StrikeDelivery : DeliveryBase
	{
		public StrikeDelivery(int pinsKnockedDown) : base(pinsKnockedDown)
		{ }
	}
}
