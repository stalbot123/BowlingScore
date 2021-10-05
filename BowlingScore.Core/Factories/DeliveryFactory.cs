using BowlingScore.Core.Interfaces;
using BowlingScore.Core.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Factories
{
	public static class DeliveryFactory
	{
		public static IDeliveryType CreateDeliveryType(int currentId, int pinsKnockedDown, StandardDelivery previousDelivery = null)
		{
			if (pinsKnockedDown == 10)
				return new StrikeDelivery(currentId, 10);
			else if (previousDelivery != null && previousDelivery.PinsKnockedDown + pinsKnockedDown == 10)
				return new SpareDelivery(currentId, pinsKnockedDown);
			else
				return new StandardDelivery(currentId, pinsKnockedDown);

		}
	}
}
