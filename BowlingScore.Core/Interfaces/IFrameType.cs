using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Interfaces
{
	public interface IFrameType
	{
		int FrameNumber { get; set; }
		int FrameScore { get; set; }
		ICollection<IDeliveryType> Deliveries { get; set; }
	}
}
