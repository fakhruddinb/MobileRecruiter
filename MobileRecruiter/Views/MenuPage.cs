using System;
using Xamarin.Forms;

namespace MobileRecruiter
{
	public class MenuLabel: Label
	{
		public MenuLabel()
		{
			WidthRequest = 200;
			XAlign = TextAlignment.Start;
			Font = Font.SystemFontOfSize (18);
		}
	}
	public class MenuPage: ContentPage
	{
		public HomePage home {get; set;}
		public MenuPage (HomePage _home)
		{

			home = _home;
			TapGestureRecognizer labelTap = new TapGestureRecognizer ();
			VerticalStack pageStack = new VerticalStack ();
			pageStack.Spacing = 10;
			this.Title = "Menu";
			this.Icon = Device.OS == TargetPlatform.iOS ? "menu-btn.png" : null;

			Image logo = new Image ();
			logo.Source = ImageSource.FromFile ("Churchill.png");
			logo.HeightRequest = 50;
			pageStack.Children.Add (logo);

			MenuLabel Home = new MenuLabel ();
			Home.Text = "Home";
			Home.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (Home);


			MenuLabel Refer = new MenuLabel ();
			Refer.Text = "Refer a Contractor";
			Refer.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (Refer);

			MenuLabel Amend = new MenuLabel ();
			Amend.Text = "Amend My Details";
			Amend.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (Amend);

			MenuLabel Terms = new MenuLabel ();
			Terms.Text = "Terms & Conditions";
			Terms.XAlign = TextAlignment.Center;
			Terms.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (Terms);

			MenuLabel AboutUs = new MenuLabel ();
			AboutUs.Text = "About Us";
			AboutUs.XAlign = TextAlignment.Start;
			AboutUs.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (AboutUs);

			MenuLabel ContactUs = new MenuLabel ();
			ContactUs.Text = "Contact Us";
			ContactUs.XAlign = TextAlignment.Center;
			ContactUs.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (ContactUs);

			MenuLabel Calculator = new MenuLabel ();
			Calculator.Text = "Take home Pay Calculator";
			Calculator.XAlign = TextAlignment.Start;
			Calculator.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (Calculator);

			MenuLabel Chart = new MenuLabel ();
			Chart.Text = "Weekly Pay Chart";
			Chart.XAlign = TextAlignment.Start;
			Chart.GestureRecognizers.Add (labelTap);
			pageStack.Children.Add (Chart);


			labelTap.Tapped+= (object sender, EventArgs e) => 
			{
				MenuLabel senderName =  sender as MenuLabel;
				home.updateDetailPage(senderName.Text);
			};
			Content = pageStack;

		}


	}
}

