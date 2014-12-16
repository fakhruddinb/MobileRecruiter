using System;

namespace MobileRecruiter
{
	public class Agent
	{
		[PrimaryKey, AutoIncrement]
		public int AgentId{ get; set;}
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string AgencyName { get; set; }
	}
}

