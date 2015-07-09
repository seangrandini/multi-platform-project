using alertApp;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
namespace alertApp
{
    class settingsPage : ContentPage
    {
        public settingsPage(string s)
        {
			NavigationPage.SetHasNavigationBar(this, false);
			Button alarmButton = new Button
			{
				Text = "Change default alarm",

			};
			alarmButton.Clicked += (sender, args) =>
			{
				if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
				{
					DependencyService.Get<IActivityInterface>().RingtonePicker();
				}
				else
				{
					Navigation.PushAsync(new ringtonesPage());
				}
			};

			Label alarmLabel = new Label
			{
				Text = s,
				YAlign = TextAlignment.Center,
				FontSize = 18,
				TranslationX = 15,

			};


			Label alarmTitle = new Label
			{
				Text = "Alarm settings",
				FontSize = 24
			};

			Label notificationTitle = new Label
			{
				Text = "Notification Settings",
				FontSize = 24
			};

			Button notificationDeleteButton = new Button
			{
				Text = "Delete All notification",
			};
			notificationDeleteButton.Clicked += async (sender, args) =>
			{
				var answer = await DisplayAlert("Warning", "Notification history will be deleted, are you sure?", "Yes", "No");
				System.Diagnostics.Debug.WriteLine("Answer: " + answer);
				if (answer)
				{
					sharedLogic.notifications.Clear();
				}
			};

			Label notificationMaxNumberLabel = new Label
			{
				Text = "Max notification number:",
				FontSize = 16
			};
			Entry notificationMaxNumberEntry = new Entry
			{
				Text = sharedLogic.settings.notificationSaveNumber.ToString()
			};
			Button notificationMaxNumberButton = new Button
			{
				Text = "Apply"
			};
			notificationMaxNumberButton.Clicked += (sender, e) =>
			{
				try
				{
					sharedLogic.settings.notificationSaveNumber = Convert.ToInt32(notificationMaxNumberEntry.Text);
					sharedLogic.database.SaveItem(sharedLogic.settings);
					sharedLogic.notificationSaveNumber = sharedLogic.settings.notificationSaveNumber;
					DisplayAlert("Info", "Now you can store " + sharedLogic.notificationSaveNumber + " notifications", "OK");
				}
				catch
				{
					DisplayAlert("Warning", "Insert only whole numbers", "OK");
					notificationMaxNumberEntry.Text = sharedLogic.notificationSaveNumber.ToString();
				}
			};

			StackLayout notificationMaxNumberSettings = new StackLayout
			{
				Padding = 0,
				Spacing = 0,
				Orientation = StackOrientation.Vertical,
				Children =
				{
					notificationMaxNumberLabel,
					notificationMaxNumberEntry,
					notificationMaxNumberButton
				}
			};

			StackLayout alarmSettings = new StackLayout
			{
				Padding = 0,
				Spacing = 0,
				Children =
				{
					alarmButton,
					alarmLabel
				}
			};

			StackLayout notificationSettings = new StackLayout
			{
				Padding = 0,
				Spacing = 0,
				Children =
				{
					notificationDeleteButton,
					notificationMaxNumberSettings
				}
			};

			this.Content = new ScrollView
			{
				Content = new StackLayout
				{
					Padding = 10,
					Spacing = 10,
					Children =
					{
						alarmTitle,
						alarmSettings,
						notificationTitle,
						notificationSettings
					}
				}
			};
		}
        public settingsPage()
        {
			NavigationPage.SetHasNavigationBar(this, false);
			Button alarmButton = new Button
            {
                Text = "Change default alarm",

            };
            alarmButton.Clicked += (sender, args) =>
            {
                if (Device.OS != TargetPlatform.WinPhone)
                {
                    DependencyService.Get<IActivityInterface>().RingtonePicker();
                }
                else
                {
                    Navigation.PushAsync(new ringtonesPage());
                }
            };

            Label alarmTitle = new Label
            {
                Text = "Alarm settings",
                FontSize = 24
            };

            Label notificationTitle = new Label
            {
                Text = "Notification Settings",
                FontSize = 24
            };

            Button notificationDeleteButton = new Button
            {
                Text = "Delete All notification",
            };
			notificationDeleteButton.Clicked += async (sender, args) =>
			{
				var answer = await DisplayAlert("Warning", "Notification history will be deleted, are you sure?", "Yes", "No");
				System.Diagnostics.Debug.WriteLine("Answer: " + answer);
				if (answer)
				{
					sharedLogic.notifications.Clear();
				}
			};

			Label notificationMaxNumberLabel = new Label
			{
				Text = "Max notification number:",
				FontSize = 16
			};
			Entry notificationMaxNumberEntry = new Entry
			{
				Text = sharedLogic.settings.notificationSaveNumber.ToString()
			};
			Button notificationMaxNumberButton = new Button
			{
				Text = "Apply"
			};
			notificationMaxNumberButton.Clicked += (sender, e) =>
			{
				try
				{
					sharedLogic.settings.notificationSaveNumber = Convert.ToInt32(notificationMaxNumberEntry.Text);
					sharedLogic.database.SaveItem(sharedLogic.settings);
					sharedLogic.notificationSaveNumber = sharedLogic.settings.notificationSaveNumber;
					DisplayAlert("Info", "Now you can store " + sharedLogic.notificationSaveNumber + " notifications", "OK");
				}
				catch
				{
					DisplayAlert("Warning", "Insert only whole numbers", "OK");
					notificationMaxNumberEntry.Text = sharedLogic.notificationSaveNumber.ToString();
				}
			};

			StackLayout notificationMaxNumberSettings = new StackLayout
			{
				Padding = 0,
				Spacing = 0,
				Orientation = StackOrientation.Vertical,
				Children =
				{
					notificationMaxNumberLabel,
					notificationMaxNumberEntry,
					notificationMaxNumberButton
				}
			};

			StackLayout alarmSettings = new StackLayout
			{
				Padding = 0,
				Spacing = 0,
				Children =
				{
					alarmButton
				}
			};

			StackLayout notificationSettings = new StackLayout
			{
				Padding = 0,
				Spacing = 0,
				Children =
				{
					notificationDeleteButton,
					notificationMaxNumberSettings
				}
			};

			this.Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Padding = 10,
					Spacing = 10,
                    Children =
                    {
                        alarmTitle,
                        alarmSettings,
                        notificationTitle,
						notificationSettings
					}
                }
            };
        }
    }
}
