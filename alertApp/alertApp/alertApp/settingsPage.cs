using alertApp;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace alertApp
{
    class settingsPage : ContentPage
    {
        public settingsPage()
        {
            Label alarmTitle = new Label
            {
                Text = "Alarm settings",
                FontSize = 24
            };
            Label alarmLabel = new Label
            {
                Text = "Alarm song:",
                YAlign = TextAlignment.Center,
                FontSize = 14
            };
            Label alarmSong = new Label
            {
                Text = "",
                FontSize = 14

            };
            Button alarmButton = new Button
            {
                Text = "Change"
            };
            alarmButton.Clicked += (sender, args) =>
            {
                DependencyService.Get<IActivityInterface>().RingtonePicker();
            };

            StackLayout alarmSongSetting = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill,
                TranslationX = 30
            };
            alarmSongSetting.Children.Add(alarmLabel);
            alarmSongSetting.Children.Add(alarmSong);
            alarmSongSetting.Children.Add(alarmButton);

            Label notificationTitle = new Label
            {
                Text = "Notification Settings",
                FontSize = 24,


            };
            Label notificationDeleteLabel = new Label
            {
                Text = "Delete All notification",
                YAlign = TextAlignment.Center,
                FontSize = 14
            };
            Button notificationDeleteButton = new Button
            {
                Text = "Delete"
            };

            StackLayout notificationDeleteSetting = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill,
                TranslationX = 30
            };
            notificationDeleteSetting.Children.Add(notificationDeleteLabel);
            notificationDeleteSetting.Children.Add(notificationDeleteButton);

            this.Content = new ScrollView
            {
                Content = new StackLayout
                {
                    TranslationX = 10,
                    Children =
                    {
                        alarmTitle,
                        alarmSongSetting,
                        notificationTitle,
                        notificationDeleteSetting

                    }
                }
            };
        }
    }
}
