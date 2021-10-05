using BowlingScore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.NewModels
{
	public class DeliveryBase : IDeliveryType
	{
		public DeliveryBase(int deliveryId, int pinsKnockedDown)
		{
			this.DeliveryId = deliveryId;
			this.PinsKnockedDown = pinsKnockedDown;
		}

		public int DeliveryId { get; set; }
		public int PinsKnockedDown { get; set; }
		
	}
}
