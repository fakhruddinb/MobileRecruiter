using System;
using Xamarin.Forms;

namespace MobileRecruiter
{
	public class SignInPage: ContentPage
	{

		public SignInPage ()
		{

			this.Title = "Sign In";
			VerticalStack PageStack = new VerticalStack ();

			VerticalStack SignInStack = new VerticalStack ();

			HorizontalStack EmailStack = new HorizontalStack ();
			TextLabel EmailLabel = new TextLabel ();
			EmailLabel.Text = "Email";
			TextField EmailField = new TextField ();
			EmailStack.Children.Add (EmailLabel);
			EmailStack.Children.Add (EmailField);


			HorizontalStack PasswordStack = new HorizontalStack ();
			TextLabel PasswordLabel = new TextLabel ();
			PasswordLabel.Text = "Password";
			TextField PasswordField = new TextField ();
			PasswordStack.Children.Add (PasswordLabel);
			PasswordStack.Children.Add (PasswordField);

			Button ForgotPasswordButton = new Button ();
			ForgotPasswordButton.Text = "I Forgot my Password";

			VerticalStack ButtonStack = new VerticalStack ();
			Button RegisterButton = new Button ();
			RegisterButton.Text = "Sign In";
			RegisterButton.BackgroundColor = Color.FromHex("22498a");
			RegisterButton.TextColor = Color.White;
			RegisterButton.Clicked+= (object sender, EventArgs e) => 
			{
				this.Navigation.PushAsync(new HomePage());
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
	}
}

