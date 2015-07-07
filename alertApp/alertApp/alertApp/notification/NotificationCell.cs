using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace alertApp
{
    class NotificationCell : ViewCell
    {
		public NotificationCell()
		{
			var Title = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				FontSize = 20
			};
			Title.SetBinding(Label.TextProperty, "Title");

			var Text = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				FontSize = 16
			};
			Text.SetBinding(Label.TextProperty, "Text");
			var viewlayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { Title, Text }
			};
			View = viewlayout;
		}
    }
}
