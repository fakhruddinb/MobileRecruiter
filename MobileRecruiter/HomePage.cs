﻿using System;
using Xamarin.Forms;

namespace MobileRecruiter
{
	public class HomePage: ContentPage
	{
		public HomePage ()
		{
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

			TapGestureRecognizer tap = new TapGestureRecognizer ();


			Image Refer = new Image ();
			Refer.Source = ImageSource.FromFile ("home-header.jpg");
			Refer.GestureRecognizers.Add (tap);
			Button ReferButton = new Button ();
			ReferButton.Text = "Refer A Contractor";

			ReferButton.TextColor = Color.Black;
			pageGrid.Children.Add ((Refer), 0, 0);
			//pageGrid.Children.Add ((ReferButton), 0, 0);


			Image Contractors = new Image ();
			Contractors.Source = ImageSource.FromFile ("feature-img-18.jpg");
			pageGrid.Children.Add ((Contractors), 1, 0);
			Contractors.GestureRecognizers.Add (tap);

			Image AmendDetails = new Image ();
			AmendDetails.Source = ImageSource.FromFile ("recruitment-zone-header.jpg");
			pageGrid.Children.Add ((AmendDetails), 0, 1);

			Image AboutUs = new Image ();
			AboutUs.Source = ImageSource.FromFile ("feature-img-20.jpg");
			pageGrid.Children.Add ((AboutUs), 1, 1);

			Image Paycal = new Image ();
			Paycal.Source = ImageSource.FromFile ("feature-img-02.jpg");
			pageGrid.Children.Add ((Paycal), 0, 2);

			Image PayChart = new Image ();
			PayChart.Source = ImageSource.FromFile ("feature-img-07.jpg");
			pageGrid.Children.Add ((PayChart), 1, 2);s

			VerticalStack ButtonStack = new VerticalStack ();
			Button TermsButton = new Button ();
			TermsButton.Text = "Download Terms & Conditions";
			TermsButton.BackgroundColor = Color.FromHex("f7941d");
			TermsButton.TextColor = Color.White;

			Button ContactUsButton = new Button ();
			ContactUsButton.Text = "Contact Us";
			ContactUsButton.BackgroundColor = Color.FromHex("0d9c00");
			ContactUsButton.TextColor = Color.White;

			ButtonStack.Children.Add (TermsButton);
			ButtonStack.Children.Add (ContactUsButton);
			pageStack.Children.Add (pageGrid);
			pageStack.Children.Add (ButtonStack);

			tap.Tapped+= (object sender, EventArgs e) => 
			{
				if (object.Equals(sender,Refer))
				{
					Console.WriteLine("DEtected");
				}
				else
					Console.WriteLine("DEtected222");
				};

			Content = pageStack;
		}
		void onTapGestureRecognizerTapped (object sender, EventArgs args)
		{
			Console.WriteLine ("TRriggered");
		}
	}


}
