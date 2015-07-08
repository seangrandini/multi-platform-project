using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace alertApp
{
    class mainPage : ContentPage
    {
		public static Label status;

		public static ListView notificationList;

		public static StackLayout footer;
		public mainPage()
        {
			Label title = new Label
            {
                Text = "AlarmApp",
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 50,
                TranslationX = 30
            };

            status = new Label
            {
                Text = "Status:",
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
                FontSize = 16
            };
			/*if (sharedLogic.internetStatus != null)
			{
				if (sharedLogic.internetStatus == 0)
				{
					status.Text = "Status: Disconnected " + DateTime.Now;
				}
				else if (sharedLogic.internetStatus == 1)
				{
					status.Text = "Status: Connected " + DateTime.Now;
				}
			}*/


			notificationList = new ListView
			{
				//MinimumHeightRequest = 200,
				//HeightRequest = 80
				HasUnevenRows = true

            };
			notificationList.ItemsSource = sharedLogic.notifications.notifactionList;
			notificationList.BindingContext = sharedLogic.notifications;
			notificationList.SetBinding(ListView.ItemsSourceProperty, "notifactionList");
			notificationList.ItemTemplate = new DataTemplate(typeof(NotificationCell));
			notificationList.ItemSelected += async (sender, e) =>
			{
				if (e.SelectedItem == null) return;
				var notifica = (Notifica)e.SelectedItem;
				await Navigation.PushAsync(new MoreDetailsPage(notifica));
				//notificationList.ClearValue(ListView.SelectedItemProperty);
				notificationList.SelectedItem = null;	
			};
			if (sharedLogic.notifications.notificationNumber > 0)
			{
				notificationList.ScrollTo(sharedLogic.notifications.notifactionList[sharedLogic.notifications.notificationNumber - 1], ScrollToPosition.End, false);
			}

            StackLayout header = new StackLayout
            {
                Padding = 0,
                Spacing = 0,
                HeightRequest = 0,
                WidthRequest = 0
            };


            StackLayout content = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            content.Children.Add(notificationList);

			footer = new StackLayout
			{
				Spacing = 0,
				Padding = 10,
				VerticalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Fill,
				BackgroundColor = Color.FromRgb(106, 196, 49),
				//HeightRequest = 30
				MinimumHeightRequest = 30
            };
            footer.Children.Add(status);

            this.Content = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                Children =
                {
                    header,
                    content,
                    footer,
                }
            };
        }
    }
}