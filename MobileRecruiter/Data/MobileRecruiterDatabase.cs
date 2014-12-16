using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace MobileRecruiter
{
	public class MobileRecruiterDatabase
	{
		static object locker = new object ();

		SQLiteConnection database;

		string DatabasePath {
			get { 
				var sqliteFilename = "MobileRecruiter.db3";
				#if __IOS__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				var path = Path.Combine(libraryPath, sqliteFilename);
				#else
				#if __ANDROID__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				var path = Path.Combine(documentsPath, sqliteFilename);
				#else
				// WinPhone
				var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
				    #endif
				#endif
				return path;
			}
		}

		public MobileRecruiterDatabase ()
		{
			database = new SQLiteConnection (DatabasePath);
			// create the tables
			database.CreateTable<Agent>();
			database.CreateTable<Contractor> ();
		}

		#region Agent
		public IEnumerable<Agent> GetAgents ()
		{
			lock (locker) {
				return (from i in database.Table<Agent>() select i).ToList();
			}
		}

		public Agent GetAgent (int id) 
		{
			lock (locker) {
				return database.Table<Agent>().FirstOrDefault(x => x.AgentId == id);
			}
		}

		public int SaveAgent (Agent agent) 
		{
			lock (locker) {
				if (agent.AgentId != 0) {
					database.Update(agent);
					return agent.AgentId;
				} else {
					return database.Insert(agent);
				}
			}
		}

		public int DeleteAgent(int id)
		{
			lock (locker) {
				return database.Delete<Agent>(id);
			}
		}

		#endregion

		#region contractor

		public IEnumerable<Contractor> GetContractors(string agentEmail)
		{
			lock (locker) {
				return database.Table<Contractor> ().Where (x => x.AgentId == agentEmail).ToList ();
			}
		}

		public Contractor GetContractor(int id)
		{
			lock (locker) {
				return database.Table<Contractor> ().FirstOrDefault (x => x.Id == id);
			}
		}

		public int SaveContractor(Contractor contractor)
		{
			lock (locker) {
				if (contractor.Id != 0) {
					database.Update(contractor);
					return contractor.Id;
				} else {
					return database.Insert(contractor);
				}
			}
		}

		public int DeleteContractor(int id)
		{
			lock (locker) {
				return database.Delete<Contractor>(id);
			}
		}
		#endregion
	}
}

