using System;
using Xamarin.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Linq;


namespace MobileRecruiter
{
	public class SignInPage: ContentPage
	{
		ActivityIndicator indicator;
		Label networkLabel;
		public SignInPage ()
		{

			this.Title = "Sign In";
			VerticalStack PageStack = new VerticalStack ();

			VerticalStack SignInStack = new VerticalStack ();

			HorizontalStack NetworkStack = new HorizontalStack ();
			networkLabel = new Label ();
			networkLabel.Text = "Connecting to Server...";
			networkLabel.TextColor = Color.White;

			indicator = new ActivityIndicator();
			indicator.Color = Color.Black;
			indicator.VerticalOptions = LayoutOptions.CenterAndExpand;
			indicator.IsRunning = false;
			indicator.IsVisible = false;

			NetworkStack.Children.Add (networkLabel);
			NetworkStack.Children.Add (indicator);
			SignInStack.Children.Add (NetworkStack);

			HorizontalStack EmailStack = new HorizontalStack ();
			TextLabel EmailLabel = new TextLabel ();
			EmailLabel.Text = "Email";
			TextField EmailField = new TextField ();
			EmailField.Text = "fakhruddin.bh.net@gmail.com";
			EmailStack.Children.Add (EmailLabel);
			EmailStack.Children.Add (EmailField);


			HorizontalStack PasswordStack = new HorizontalStack ();
			TextLabel PasswordLabel = new TextLabel ();
			PasswordLabel.Text = "Password";
			TextField PasswordField = new TextField ();
			PasswordField.Text = "tetssttee";
			PasswordStack.Children.Add (PasswordLabel);
			PasswordStack.Children.Add (PasswordField);

			Button ForgotPasswordButton = new Button ();
			ForgotPasswordButton.Text = "I Forgot my Password";

			VerticalStack ButtonStack = new VerticalStack ();
			Button RegisterButton = new Button ();
			RegisterButton.Text = "Sign In";
			RegisterButton.BackgroundColor = Color.FromHex("22498a");
			RegisterButton.TextColor = Color.White;
			RegisterButton.Clicked+= async (object sender, EventArgs e) => 
			{
				bool flag = true;
				if(string.IsNullOrWhiteSpace(EmailField.Text) ){ EmailLabel.TextColor = Color.Red; flag = false;} else {EmailLabel.TextColor = Color.Black; flag = true;}

				if(!IsValidEmail(EmailField.Text))
				{
					EmailField.TextColor = Color.Red;
					flag = false;
					await DisplayAlert ("Email Error!!", "Invalid Email ID", "OK");
				}
				else
					if(string.IsNullOrWhiteSpace(PasswordField.Text)) {PasswordLabel.TextColor = Color.Red; flag = false;} 
					else 
					{
						PasswordLabel.TextColor = Color.Black; flag = true;
						UriBuilder getAgentURI = new UriBuilder ("http://134.213.136.240:1081/api/agents/"+EmailField.Text);
						HttpWebRequest getAgentRequest = (HttpWebRequest)WebRequest.Create (getAgentURI.Uri);
						getAgentRequest.Method = WebRequestMethods.Http.Get;
						getAgentRequest.Accept = "application/json";
						indicator.IsVisible = true;
						indicator.IsRunning = true;
						networkLabel.TextColor = Color.Blue;
						HttpWebResponse response = await getAgentRequest.GetResponseAsync() as HttpWebResponse;
						if (response.StatusCode != HttpStatusCode.OK) 
						{
							Console.WriteLine ("Error Fetching Agent Details");
						}
						else
						{
							using (StreamReader reader = new StreamReader (response.GetResponseStream()))
							{
								var content = reader.ReadToEnd ();

								if (string.IsNullOrWhiteSpace (content)) {
									Console.WriteLine ("No Response Data");

								} else
								{
									string htmlStr = content;
									string[] arr = htmlStr.Split(new[] { ',' },StringSplitOptions.RemoveEmptyEntries);
									// convert to a Dictionary
									var dict1 = arr
										.Select(x => x.Split(':'))
										.ToDictionary(i => i[0], i => i[1]); 

									var list = dict1.ToList();
									//

									indicator.IsRunning = false;
									indicator.IsVisible = false;
									networkLabel.TextColor = Color.White;
									await this.Navigation.PushModalAsync(new HomePage());
								}
							}
						}

					}

			};

			Button AccountHolder = new Button ();
			AccountHolder.Text = "I don't have a Recruiter Account...";
			AccountHolder.BackgroundColor = Color.FromHex("3b73b9");
			AccountHolder.TextColor = Color.White;

			Button TermsButton = new Button ();
			TermsButton.Text = "Download Terms & Conditions";
			TermsButton.BackgroundColor = Color.FromHex("f7941d");
			TermsButton.TextColor = Color.White;

			Button ContactUsButton = new Button ();
			ContactUsButton.Text = "Contact Us";
			ContactUsButton.BackgroundColor = Color.FromHex("0d9c00");
			ContactUsButton.TextColor = Color.White;

			ButtonStack.Children.Add (RegisterButton);
			ButtonStack.Children.Add (AccountHolder);
			ButtonStack.Children.Add (TermsButton);
			ButtonStack.Children.Add (ContactUsButton);

			AccountHolder.Clicked += (object sender, EventArgs e) => 
			{
				this.Navigation.PopAsync();
			};



			SignInStack.Children.Add (EmailStack);
			SignInStack.Children.Add (PasswordStack);
			SignInStack.Children.Add (ForgotPasswordButton);
			PageStack.Children.Add (SignInStack);
			PageStack.Children.Add (ButtonStack);

			Content = PageStack;
		}
		public static bool IsValidEmail(string strIn)
		{
			// Return true if strIn is in valid e-mail format.
			return Regex.IsMatch(strIn,
				@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
		}
	}

}

