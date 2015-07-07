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
				VerticalOptions = LayoutOptions.Start,
				FontSize = 20
			};
			Title.SetBinding(Label.TextProperty, "TitlePreview");

			var Text = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				FontSize = 16
			};
			Text.SetBinding(Label.TextProperty, "TextPreview");

			var Data = new Label
			{
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Start,
				FontSize = 16,
			};
			Data.SetBinding(Label.TextProperty, "Data");

			var viewlayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { Title, Text, Data }
			};
			View = viewlayout;
		}
    }
}
