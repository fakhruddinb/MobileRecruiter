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
		private string contractorDataUrl = "http://134.213.136.240:1081/api/agents";
		public ContractorCalls ()
		{
		}

		private ContractorPage callerPage { get; set;}
		public void AddContractor (string userName, ContractorPage contractorPage)
			{
				callerPage = contractorPage;
			UriBuilder addContractorURI = new UriBuilder (contractorDataUrl+ "/?agent=" + userName);
			addContractorURI.Query = "&AgentId=" + WebUtility.HtmlEncode (userName) + WebUtility.HtmlEncode("&FirstName=Ankit&LastName=Sanghvi&Email=ankit.s.net@gmail.com&Phone=1234567890&AdditionalInformation=Nothing&InsertDate=2014-11-20T00:00:00");
			HttpWebRequest addContractorRequest = (HttpWebRequest)WebRequest.Create (signUpURI.Uri);

			using (HttpWebResponse response = addContractorRequest.GetResponse () as HttpWebResponse) 
				{
					if (response.StatusCode != HttpStatusCode.OK)
						Console.WriteLine (response.StatusCode);
					else 
					{
						//this.callerPage.UpdateUI (response.StatusCode.ToString());
					}
				}
				//			
		}
	}
}

