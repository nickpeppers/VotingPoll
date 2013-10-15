using System;
using System.Linq;
using System.Runtime.Serialization;

namespace VotingPoll
{
	public class Poll
	{
        // Poll class to get/set poll information
		public int Id { get; set;}
		public string Question { get; set; }
        public string Choices { get; set; }
        public string Votes { get; set; }
        // overrides the ToString method to easily shows the question in the table
        public override string ToString()
        {
            return Question;
        }
	}
}

