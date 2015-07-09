using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace alertApp
{
    class MoreDetailsPage : ContentPage
    {
		public MoreDetailsPage(Notifica notifica)
		{
			
			NavigationPage.SetHasNavigationBar(this, false);
			Label TitleLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				FontSize = 36,
				Text = notifica.Title
			};

			Label TextLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				FontSize = 18,
				Text = notifica.Text
			};

			Label DataLabel = new Label
			{
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Start,
				FontSize = 18,
				Text = notifica.Data
			};

			Button DeleteButton = new Button
			{
				VerticalOptions = LayoutOptions.End,
				FontSize = 18,
				Text = "Delete" + notifica.Index
			};
			DeleteButton.Clicked += async (sender, args) =>
			{
				var answer = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");
				if (answer)
				{
					sharedLogic.notifications.DeleteAt(notifica.Index);
				}
				await Navigation.PopAsync();
			};

				this.Content = new StackLayout
			{
				Spacing = 0,
				Padding = 0,
				Children =
				{
					TitleLabel,
					TextLabel,
					DataLabel,
					DeleteButton
				}
			};
		}
	}
}
