using System;
using System.Linq;
using System.Runtime.Serialization;

namespace VotingPoll
{
	public class Poll
	{
		public int Id { get; set;}
		public string Question { get; set; }
        public string Choices { get; set; }
        public string Votes { get; set; }
        public override string ToString()
        {
            return Question;
        }
	}
}

