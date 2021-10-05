using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Interfaces
{
	public interface IDeliveryType
	{
		int DeliveryId { get; set; }
		int PinsKnockedDown { get; set; }
	}
}
