using System;
using SQLite;

namespace VotingPoll
{
	public class Candidate
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set;}
		public string FirstName { get; set;}
		public string LastName { get; set;}
		public int Votes { get; set;}
	}
}

