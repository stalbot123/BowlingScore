using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Models
{
	public class Delivery
	{
		public bool IsStrike { get; set; }
		public bool IsSpare { get; set; }
		public int Score { get; set; }
	}
}
