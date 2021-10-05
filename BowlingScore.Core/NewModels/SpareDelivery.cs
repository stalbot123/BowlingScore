using BowlingScore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.NewModels
{
	public class SpareDelivery : DeliveryBase
	{
		public SpareDelivery(int deliveryId, int pinsKnockedDown):base(deliveryId, pinsKnockedDown)
		{ }
	}
}
