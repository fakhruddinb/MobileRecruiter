using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
namespace MobileRecruiter
{
	public class ContractorCalls
	{
		private string contractorDataUrl = "http://134.213.136.240:1081/api/contractors";
		public ContractorCalls ()
		{
		}

		private ContractorPage callerPage { get; set;}
		public void AddContractor (string userName, ContractorPage contractorPage)
			{
				callerPage = contractorPage;
			UriBuilder addContractorURI = new UriBuilder (contractorDataUrl+ "/?agent=" + userName);
			addContractorURI.Query = "&AgentId=" + WebUtility.HtmlEncode (userName) + WebUtility.HtmlEncode("&FirstName=Ankit&LastName=Sanghvi&Email=ankit.s.net@gmail.com&Phone=1234567890&AdditionalInformation=Nothing&InsertDate=2014-11-20T00:00:00");
			HttpWebRequest addContractorRequest = (HttpWebRequest)WebRequest.Create(addContractorURI.Uri);
			using (HttpWebResponse response = addContractorRequest.GetResponse () as HttpWebResponse) 
				{
				if (response.StatusCode != HttpStatusCode.OK) {
					Console.WriteLine (response.StatusCode);
				}
					else 
					{
						//this.callerPage.UpdateUI (response.StatusCode.ToString());
					}
				}
				//			
		}

		public string GetContractor(string agentEmail,string contractorId)
		{
			string contractorData = null;
			UriBuilder getContractorURI = new UriBuilder (contractorDataUrl+"/"+contractorId+"agent="+agentEmail);
			HttpWebRequest getContractorRequest = (HttpWebRequest)WebRequest.Create (getContractorURI.Uri);
			getContractorRequest.Method = WebRequestMethods.Http.Get;
			getContractorRequest.Accept = "application/json";
			using (HttpWebResponse response =  getContractorRequest.GetResponse () as HttpWebResponse)
				if (response.StatusCode != HttpStatusCode.OK) 
				{
					Console.WriteLine ("Error Fetching Agent Details");
					contractorData = "Error";
				}
				else
				{

					using (StreamReader reader = new StreamReader (response.GetResponseStream()))
					{
						var content = reader.ReadToEnd();
						if (string.IsNullOrWhiteSpace (content)) {
							Console.WriteLine ("No Response Data");
							contractorData = "Empty";

						} else
							contractorData = content;

					}
				}
			return contractorData;
		}

		public string GetContractors(string agentEmail)
		{
			string contractorsData = null;
			UriBuilder getContractorsURI = new UriBuilder (contractorDataUrl+"?agent="+agentEmail);
			HttpWebRequest getContractorsRequest = (HttpWebRequest)WebRequest.Create (getContractorsURI.Uri);
			getContractorsRequest.Method = WebRequestMethods.Http.Get;
			getContractorsRequest.Accept = "application/json";
			using (HttpWebResponse response =  getContractorsRequest.GetResponse () as HttpWebResponse)
				if (response.StatusCode != HttpStatusCode.OK) 
				{
					Console.WriteLine ("Error Fetching Agent Details");
					contractorsData = "Error";

				}
				else
				{

					using (StreamReader reader = new StreamReader (response.GetResponseStream()))
					{
						var content = reader.ReadToEnd();
						if (string.IsNullOrWhiteSpace (content)) {
							Console.WriteLine ("No Response Data");
							contractorsData = "Empty";

						} else
							contractorsData = content;

					}
				}
			return contractorsData;
		}

		public void UpdateContractor(string agentEmail,ContractorPage contractorPage)
		{
			callerPage = contractorPage;
			UriBuilder updateContractorURI = new UriBuilder (contractorDataUrl+"?agent="+agentEmail);
			updateContractorURI.Query = "&AgentId=" + WebUtility.HtmlEncode (agentEmail) + WebUtility.HtmlEncode("&FirstName=Ankit&LastName=Sanghvi&Email=ankit.s.net@gmail.com&Phone=1234567890&AdditionalInformation=Nothing&InsertDate=2014-11-20T00:00:00");
			HttpWebRequest updateContractorRequest = (HttpWebRequest)WebRequest.Create(updateContractorURI.Uri);
			updateContractorRequest.Method = WebRequestMethods.Http.Put;
			updateContractorRequest.Accept = "application/json";
			using (HttpWebResponse response = updateContractorRequest.GetResponse () as HttpWebResponse) 
			{
				if (response.StatusCode != HttpStatusCode.OK)
					Console.WriteLine (response.StatusCode);
				else 
				{
					//this.callerPage.UpdateUI (response.StatusCode.ToString());
				}
			}
		}

		public void DeleteContractor(string agentEmail,string contractorId)
		{
			UriBuilder deleteContractorURI = new UriBuilder (contractorDataUrl+"/"+contractorId+"agent="+agentEmail);
			HttpWebRequest deleteContractorRequest = (HttpWebRequest)WebRequest.Create(deleteContractorURI.Uri);
			deleteContractorRequest.Method = "DELETE";
			deleteContractorRequest.Accept = "application/json";
			using (HttpWebResponse response = deleteContractorRequest.GetResponse () as HttpWebResponse)
			{
				if (response.StatusCode != HttpStatusCode.OK)
					Console.WriteLine (response.StatusCode);
				else 
				{
					//this.callerPage.UpdateUI (response.StatusCode.ToString());
				}
			}
		}

	}
}

