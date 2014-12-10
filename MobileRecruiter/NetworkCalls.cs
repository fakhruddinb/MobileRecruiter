using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;


namespace MobileRecruiter
{
	public class NetworkCalls
	{
		public NetworkCalls ()
		{

		}
		private SignUpPage callerPage { get; set;}
		public void SignUp (string userName, SignUpPage signUpPage)
		{
			callerPage = signUpPage;
			UriBuilder signUpURI = new UriBuilder ("http://134.213.136.240:1081/test.htm");
			signUpURI.Query = "&id=" + WebUtility.HtmlEncode (userName) + WebUtility.HtmlEncode("&DeviceType=Android&DeviceOS=Android 4.4&DeviceMake=HTC&FirstName=Hal 3&LastName=Bent&Phone=11111111&AgencyName=Agent C Name&AdditionalInfo=No Info");
			HttpWebRequest signUpRequest = (HttpWebRequest)WebRequest.Create (signUpURI.Uri);

			using (HttpWebResponse response = signUpRequest.GetResponse () as HttpWebResponse) 
			{
				if (response.StatusCode != HttpStatusCode.OK)
					Console.WriteLine (response.StatusCode);
				else 
				{
					this.callerPage.UpdateUI (response.StatusCode.ToString());
				}
			}
//			
		}



	}
}

