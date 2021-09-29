using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Models
{
	public class Game
	{
		public Frame[] Frames { get; set; } = new Frame[10];
	}
}
