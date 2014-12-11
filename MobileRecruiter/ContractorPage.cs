using Xamarin.Forms;
using MobileRecruiter;
using System;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;

namespace MobileRecruiter
{
	public class ContractorPage : ContentPage
	{
		private string _baseResource;
		ActivityIndicator indicator;
		Label networkLabel;
		public string BaseResource
		{
			get
			{
				return _baseResource ?? (_baseResource = Assembly.GetExecutingAssembly().FullName.Split(',').FirstOrDefault());
			}
		}

		private ImageSource PlatformImageResource(string resource)
		{
			ImageSource x = ImageSource.FromResource (BaseResource + "." + resource);
			Console.WriteLine (x.ToString());
			return x;
		}
		public ContractorPage ()
		{

			this.Title = "Refer a contractor";


			VerticalStack PageStack = new VerticalStack ();

			VerticalStack FormStack = new VerticalStack ();

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

			FormStack.Children.Add (NetworkStack);

			HorizontalStack firstNameStack = new HorizontalStack ();

			TextLabel firstNameLabel = new TextLabel ();
			firstNameLabel.Text = "First Name";
			TextField firstNameField = new TextField ();
			firstNameStack.Children.Add (firstNameLabel);
			firstNameStack.Children.Add (firstNameField);

			HorizontalStack lastNameStack = new HorizontalStack ();
			TextLabel lastNameLabel = new TextLabel ();
			lastNameLabel.Text = "Last Name";
			TextField lastNameField = new TextField ();
			lastNameStack.Children.Add (lastNameLabel);
			lastNameStack.Children.Add (lastNameField);

			HorizontalStack phoneStack = new HorizontalStack ();
			TextLabel phoneLabel = new TextLabel ();
			phoneLabel.Text = "Phone";
			TextField phoneField = new TextField ();
			phoneStack.Children.Add (phoneLabel);
			phoneStack.Children.Add (phoneField);

			HorizontalStack emailStack = new HorizontalStack ();
			TextLabel emailLabel = new TextLabel ();
			emailLabel.Text = "Email";
			TextField emailField = new TextField ();
			emailStack.Children.Add (emailLabel);
			emailStack.Children.Add (emailField);

			VerticalStack additionalInfoStack = new VerticalStack ();
			TextLabel additionalInfoLabel = new TextLabel ();
			additionalInfoLabel.Text = "Additional Information";

			TextField additionalInfoField = new TextField ();

			additionalInfoStack.Children.Add (additionalInfoLabel);
			additionalInfoStack.Children.Add (additionalInfoField);
		
			HorizontalStack ConditionStack = new HorizontalStack ();
			TextLabel ConditionLabel = new TextLabel ();
			ConditionLabel.Text = "I Agree to the Terms & Conditions ";
			ConditionLabel.WidthRequest = 280;
			ConditionLabel.MinimumHeightRequest = 80;

			CheckedBox AgreeImage = new CheckedBox ();

			AgreeImage.Source = ImageSource.FromFile ("next.png");
			AgreeImage.WidthRequest = 30;
			AgreeImage.HeightRequest = 30;


			ConditionStack.Children.Add (ConditionLabel);
			ConditionStack.Children.Add (AgreeImage);

			VerticalStack ButtonStack = new VerticalStack ();

			Button submitButton = new Button ();
			submitButton.Text = "Submit";
			submitButton.BackgroundColor = Color.FromHex("22498a");
			submitButton.TextColor = Color.White;

			Button TermsButton = new Button ();
			TermsButton.Text = "Download Terms & Conditions";
			TermsButton.BackgroundColor = Color.FromHex("f7941d");
			TermsButton.TextColor = Color.White;

			Button ContactUsButton = new Button ();
			ContactUsButton.Text = "Contact Us";
			ContactUsButton.BackgroundColor = Color.FromHex("0d9c00");
			ContactUsButton.TextColor = Color.White;

			ButtonStack.Children.Add (submitButton);
			ButtonStack.Children.Add (TermsButton);
			ButtonStack.Children.Add (ContactUsButton);


			submitButton.Clicked += (object sender, System.EventArgs e) => 
			{
				bool flag = true;

				if(string.IsNullOrEmpty(firstNameField.Text)) {firstNameLabel.TextColor = Color.Red; flag = false;}else  {firstNameLabel.TextColor = Color.Black; flag = true;} 
				if(string.IsNullOrEmpty(lastNameField.Text)) { lastNameLabel.TextColor = Color.Red; flag = false;} else  { lastNameLabel.TextColor = Color.Black; flag = true;}
				if(string.IsNullOrEmpty(phoneField.Text)) { phoneLabel.TextColor = Color.Red; flag = false;} else  { phoneLabel.TextColor = Color.Black; flag = true; }
				if(string.IsNullOrEmpty(emailField.Text)) { emailLabel.TextColor = Color.Red; flag = false; } else  { emailLabel.TextColor = Color.Black; flag = true; }

				if(string.IsNullOrEmpty(emailField.Text))
				{
					emailField.TextColor = Color.Red;
					flag = false;
				}
				else
					if(!IsValidEmail(emailField.Text))
					{
						flag = false;
						emailLabel.TextColor = Color.Red;
						DisplayAlert("Invalid Email ID", "Please Enter a Valid Email ID", "Return");
					}
					else
					{
						flag =true;
						emailLabel.TextColor = Color.Black;
					}
				if(flag == true)
				{
					networkLabel.TextColor = Color.Blue;
					indicator.IsRunning = true;
					indicator.IsVisible = true;

					ContractorCalls call = new ContractorCalls();
					call.AddContractor(emailField.Text, this);

				}
			};

			FormStack.Children.Add (firstNameStack);
			FormStack.Children.Add (lastNameStack);
			FormStack.Children.Add (phoneStack);
			FormStack.Children.Add (emailStack);
			FormStack.Children.Add (additionalInfoStack);
			FormStack.Children.Add (ConditionStack);

			PageStack.Children.Add (FormStack);
			PageStack.Children.Add (ButtonStack);

			this.BackgroundColor = Color.White;
			Content = new ScrollView{ Content= PageStack};

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

