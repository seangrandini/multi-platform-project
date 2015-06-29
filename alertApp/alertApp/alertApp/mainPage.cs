using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace alertApp
{
    class mainPage : ContentPage
    {
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

            Label status = new Label
            {
                Text = "Status:",
                TextColor = Color.White,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Image settingsButton = new Image
            {
                Source = ImageSource.FromFile("settingsIcon_black"),
                HeightRequest = 60,
                WidthRequest = 50,
                TranslationX = 5

            };
            /*settingsButton.GestureRecognizers.Add(new TapGestureRecognizer(sender =>
            {
                Navigation.PushAsync(new settingsPage());
            }));*/

            ListView notificationList = new ListView
            {
                RowHeight = 100
            };
            notificationList.ItemsSource = new string[]
                {
                    "aaaa",
                    "bbbb",
                    "cccc",
                    "dddd",
                    "eeee",
                    "aaaa",
                    "bbbb",
                    "cccc",
                    "dddd",
                    "aaaa",
                    "bbbb",
                    "cccc",
                    "dddd",
                    "aaaa",
                    "bbbb",
                    "cccc",
                    "dddd"
                };

            StackLayout header = new StackLayout
            {
                Padding = 0,
                Spacing = 0,
                HeightRequest = 0,
                WidthRequest = 0
            };

            /*if (Device.OS == TargetPlatform.Android)
            {
                header = new StackLayout
                {
                    Spacing = 0,
                    VerticalOptions = LayoutOptions.Start,
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Fill,
                    //BackgroundColor = Color.White,
                    HeightRequest = 70,
                    //Padding = new Thickness(10)
                };
                header.Children.Add(settingsButton);
                header.Children.Add(title);
            }*/

            StackLayout content = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //BackgroundColor = Color.White
            };
            content.Children.Add(notificationList);
            //content.Children.Add(new Button() {Text="prova" });

            StackLayout footer = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.End,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromRgb(106, 196, 49),
                HeightRequest = 30
            };
            footer.Children.Add(status);

            this.Content = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                /*#if __ANDROID__
                                BackgroundColor = Color.White,
                #endif*/
                Children =
                {
                    header,
                    /*#if __ANDROID__
                                        new Shadow5px(),
                    #endif*/
                    content,
                    footer,
                }
            };
        }
    }
}