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
            Button alarmButton = new Button
            {
                Text = "Change",
                TranslationX = 0,
                
            };
            alarmButton.Clicked += (sender, args) =>
            {
                DependencyService.Get<IActivityInterface>().RingtonePicker();
            };

            Label alarmTitle = new Label
            {
                Text = "Alarm settings",
                FontSize = 24
            };
            Label alarmLabel = new Label
            {
                Text = "Change default alarm",
                YAlign = TextAlignment.Center,
                FontSize = 18,
                TranslationX= 15,
                
            };

            StackLayout alarmSongSetting = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill,
            };
            alarmSongSetting.Children.Add(alarmButton);
            //alarmSongSetting.Children.Add(alarmSong);
            alarmSongSetting.Children.Add(alarmLabel);

            Label notificationTitle = new Label
            {
                Text = "Notification Settings",
                FontSize = 24,


            };
            Label notificationDeleteLabel = new Label
            {
                Text = "Delete All notification",
                YAlign = TextAlignment.Center,
                FontSize = 18
            };
            Button notificationDeleteButton = new Button
            {
                Text = "Delete",
                TranslationX = -20,


                
            };

            AbsoluteLayout notificationDeleteSetting = new AbsoluteLayout
            {
                Padding = 0,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Fill,
            };
            AbsoluteLayout.SetLayoutFlags(notificationDeleteButton,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(notificationDeleteButton,
                new Rectangle(1f,
                    0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(notificationDeleteLabel,
            AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(notificationDeleteLabel,
                new Rectangle(0f,
                    0.5f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            notificationDeleteSetting.Children.Add(notificationDeleteLabel);
            notificationDeleteSetting.Children.Add(notificationDeleteButton);

            StackLayout prova1 = new StackLayout
            {
                Padding = 0,
            };

            Button prova = new Button
            {
                Text = "prova",

            };

            prova1.Children.Add(prova);

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
                        notificationDeleteSetting,
                        prova1,

                    }
                }
            };
        }
    }
}
