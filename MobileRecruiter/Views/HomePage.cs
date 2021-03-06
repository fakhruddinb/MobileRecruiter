﻿using System;
using Xamarin.Forms;
using System.Net;
using System.Threading.Tasks;


namespace MobileRecruiter
{
	public class HomePage: MasterDetailPage
	{
		public HomePage ()
		{
			//Master Menu
			this.Title = "Home";

			this.Master = new MenuPage (this);


			VerticalStack pageStack = new VerticalStack ();
			Grid pageGrid = new Grid ();
			pageGrid.RowSpacing = 5;
			pageGrid.RowSpacing = 2;
			ColumnDefinition column1 = new ColumnDefinition ();
			GridLength width = new GridLength (1, GridUnitType.Star);
			column1.Width = width;

			ColumnDefinition column2 = new ColumnDefinition ();
			column2.Width = width;

			RowDefinition row1 = new RowDefinition ();
			row1.Height = new GridLength (1, GridUnitType.Star);

			RowDefinition row2 = new RowDefinition ();
			row2.Height = new GridLength (1, GridUnitType.Star);

			RowDefinition row3 = new RowDefinition ();
			row3.Height = new GridLength (1, GridUnitType.Auto);

			pageGrid.ColumnDefinitions.Add(column1);
			pageGrid.ColumnDefinitions.Add(column2);
			pageGrid.RowDefinitions.Add(row1);
			pageGrid.RowDefinitions.Add(row2);
			pageGrid.RowDefinitions.Add (row3);

			TapGestureRecognizer imageTap = new TapGestureRecognizer ();


			Image Refer = new Image ();
			Refer.Source = ImageSource.FromFile ("home-header.jpg");
			Refer.GestureRecognizers.Add (imageTap);
			Button ReferButton = new Button ();
			ReferButton.Text = "Refer A Contractor";

			ReferButton.TextColor = Color.Black;
			pageGrid.Children.Add ((Refer), 0, 0);
			//pageGrid.Children.Add ((ReferButton), 0, 0);


			Image Contractors = new Image ();
			Contractors.Source = ImageSource.FromFile ("feature-img-18.jpg");
			pageGrid.Children.Add ((Contractors), 1, 0);
			Contractors.GestureRecognizers.Add (imageTap);

			Image AmendDetails = new Image ();
			AmendDetails.Source = ImageSource.FromFile ("recruitment-zone-header.jpg");
			pageGrid.Children.Add ((AmendDetails), 0, 1);
			AmendDetails.GestureRecognizers.Add (imageTap);

			Image AboutUs = new Image ();
			AboutUs.Source = ImageSource.FromFile ("feature-img-20.jpg");
			pageGrid.Children.Add ((AboutUs), 1, 1);
			AboutUs.GestureRecognizers.Add (imageTap);

			Image Paycal = new Image ();
			Paycal.Source = ImageSource.FromFile ("feature-img-02.jpg");
			pageGrid.Children.Add ((Paycal), 0, 2);
			Paycal.GestureRecognizers.Add (imageTap);

			Image PayChart = new Image ();
			PayChart.Source = ImageSource.FromFile ("feature-img-07.jpg");
			pageGrid.Children.Add ((PayChart), 1, 2);
			PayChart.GestureRecognizers.Add (imageTap);

			VerticalStack ButtonStack = new VerticalStack ();
			Button TermsButton = new Button ();
			TermsButton.Text = "Download Terms & Conditions";
			TermsButton.BackgroundColor = Color.FromHex("f7941d");
			TermsButton.TextColor = Color.White;

			Button ContactUsButton = new Button ();
			ContactUsButton.Text = "Contact Us";
			ContactUsButton.BackgroundColor = Color.FromHex("0d9c00");
			ContactUsButton.TextColor = Color.White;
			ActivityIndicator indicator = new ActivityIndicator ();
			ButtonStack.Children.Add (indicator);

			ButtonStack.Children.Add (TermsButton);
			ButtonStack.Children.Add (ContactUsButton);
			pageStack.Children.Add (pageGrid);
			pageStack.Children.Add (ButtonStack);


			imageTap.Tapped += async (object sender, EventArgs e) => 
			{
				UriBuilder getAgentURI = new UriBuilder ("http://134.213.136.240:1081/api/agents/hal@test.com");
				HttpWebRequest getAgentRequest = (HttpWebRequest)WebRequest.Create (getAgentURI.Uri);
				getAgentRequest.Method = WebRequestMethods.Http.Get;
				getAgentRequest.Accept = "application/json";
				Console.WriteLine("Started");
				indicator.IsRunning = true;
				HttpWebResponse response = await getAgentRequest.GetResponseAsync() as HttpWebResponse;
				Console.WriteLine("Completed");
				indicator.IsRunning = false;
				if(response.StatusCode!= HttpStatusCode.OK)
				{
					Console.WriteLine("Failed");
				}
				else
				{
					Console.WriteLine("Completed");
				}

			};

			//			imageTap.Tapped+= (object sender, EventArgs e) => 
			//			{
			//				if (object.Equals(sender,Refer))
			//				{
			//					Console.WriteLine("Refer");
			//				}
			//				else if (object.Equals(sender,Contractors)) {
			//					Console.WriteLine("Contractors");
			//
			//					NetworkCalls getAgentCall = new NetworkCalls();
			//					string agent =   getAgentCall.GetAgent("hal@test.com");
			//
			//					//Send parse Request or start parsing to convert it into Agent Model Object
			//				}
			//				else if(object.Equals(sender,AmendDetails))
			//				{
			//					Console.WriteLine("AmendDetails");
			//				}
			//				else if(object.Equals(sender,AboutUs))
			//				{
			//					Console.WriteLine("AboutUs");
			//				}
			//				else if(object.Equals(sender,Paycal))
			//				{
			//					Console.WriteLine("Paycal");
			//				}
			//				else if(object.Equals(sender,PayChart))
			//				{
			//					Console.WriteLine("PayChart");
			//				}
			//
			//			};


			this.Detail = new NavigationPage(new ContentPage
				{
					Title = "Home",
					Content = pageStack

				});


			//Content = pageStack;
		}
		void onTapGestureRecognizerTapped (object sender, EventArgs args)
		{
			Console.WriteLine ("TRriggered");
		}

		public void updateDetailPage(string sender)
		{
			Console.WriteLine (sender);
			if (sender.Contains ("Home")) {
				this.Detail =  new HomePage ();
			}
			if (sender.Contains ("Refer")) {
				this.Detail = new NavigationPage(new ContractorPage ());
			}
			if (sender.Contains ("Amend")) {
				this.Detail =  new HomePage ();
			}
			if (sender.Contains ("Terms")) {
				this.Detail =  new HomePage ();
			}
			if (sender.Contains ("AboutUs")) {
				this.Detail =  new HomePage ();
			}
			if (sender.Contains ("ContactUs")) {
				this.Detail =  new HomePage ();
			}
			if (sender.Contains ("Calculator")) {
				this.Detail =  new HomePage ();
			}
			if (sender.Contains ("Chart")) {
				this.Detail =  new HomePage ();
			}
			this.IsPresented = false;

		}


	}


}

