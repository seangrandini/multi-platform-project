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
				HorizontalOptions = LayoutOptions.Start
			};
			Title.SetBinding(Label.TextProperty, "Title");

			var Text = new Label
			{
				HorizontalOptions = LayoutOptions.Start
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
