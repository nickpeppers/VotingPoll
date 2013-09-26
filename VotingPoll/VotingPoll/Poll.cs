using System;

namespace VotingPoll
{
	public class Poll
	{
		public int ID { get; set;}
		public string Question { get; set;}
		public string[] Choices { get; set; }
		public int[] Votes { get; set; }
	}
}

