using System;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace MobileRecruiter
{
	public class ResourceManager: Object
	{
		private static string _baseResource;
		public static string BaseResource
		{
			get
			{
				return _baseResource ?? (_baseResource = Assembly.GetExecutingAssembly().FullName.Split(',').FirstOrDefault());
			}
		}

		public static ImageSource PlatformImageResource(string resource)
		{
			return ImageSource.FromResource(BaseResource + "." + resource);
		}

	}

	public class CheckedBox: Image
	{
		public bool flag { get; set;}

		public CheckedBox()
		{
			flag = false;
		}
	}

	public class VerticalStack: StackLayout
	{
		public VerticalStack()
		{
			Orientation = StackOrientation.Vertical;
			Spacing = 10;
			Padding = new Thickness (10);
		}
	}

	public class HorizontalStack: StackLayout
	{
		public HorizontalStack()
		{
			Orientation = StackOrientation.Horizontal;
			Spacing = 5;
		}
	}

	public class TextField: Entry
	{
		public TextField()
		{
			WidthRequest = 175;
		}
	}

	public class TextLabel: Label
	{
		public TextLabel()
		{
			WidthRequest = 120;
			YAlign = TextAlignment.Center;
			if (Device.Idiom == TargetIdiom.Phone)
				Font = Font.SystemFontOfSize (14);
			else
				Font = Font.SystemFontOfSize (16);

		}
	}

	public class App
	{
		public static Page GetMainPage ()
		{
			return new NavigationPage (new SignUpPage ());
		
		}

	}
}

