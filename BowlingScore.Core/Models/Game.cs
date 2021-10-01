using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Core.Models
{
	public class Game
	{
		public Game(string playerName)
		{
			this.PlayerName = playerName;
			this.Frames = new HashSet<Frame>();
		}
		public string PlayerName { get; set; }
		//public Frame[] Frames { get; set; } = new Frame[10];
		public ICollection<Frame> Frames { get; set; }

		private int scoreRunningTotal;
		public int ScoreRunningTotal
		{
			get
			{
				scoreRunningTotal = this.Frames.Sum(f => f.FrameScore);
				return scoreRunningTotal;
			}
		}

		public bool GameOver { get; set; }


		//private bool gameOver;
		//public bool GameOver
		//{
		//	get
		//	{
		//		if(this.Frames.FirstOrDefault(f => f.FrameNumber == 10) != null)
		//		{
		//			this.Frames.FirstOrDefault(f => f.FrameNumber == 10).Deliveries
		//		}
		//	}
		//}
	}
}
