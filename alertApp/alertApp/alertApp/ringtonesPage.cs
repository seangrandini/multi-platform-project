using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace alertApp
{
    class ringtonesPage : ContentPage
    {
        public static string gino;

        public ringtonesPage()
        {
            //var imagep = new Image { Aspect = Aspect.AspectFit };
            //imagep.Source = ImageSource.FromFile("play.png");

                ListView ringtonesList = new ListView
            {
                RowHeight = 50
            };
            ringtonesList.ItemsSource = new string[]
                {
                    "Kick in Rock",
                    "Nokia - Attraction",
                    "Nokia - Badinerie",
                    "Nokia - City Bird",
                    "Nokia - Frog",
                    "Nokia - Hurdy Gurdy",
                    "Nokia - Intro",
                    "Nokia - Jumping",
                    "Nokia - Kick",
                    "Nokia - Knick Knack",
                    "Nokia - Lamb",
                    "Nokia - Low",
                    "Nokia - Merry Xmas",
                    "Nokia - Orient",
                    "Nokia - Ring Ring",
                    "Nokia - Robo N1X",
                    "Nokia - Rocket",
                    "Nokia - Thats It",
                    "Nokia - The Buffoon",
                    "Nokia - Tick Tick",
                    "Nokia Tune 2013",
                    "Nokia Tune V2",
                    "Nokia Tune V3",
                };
            ringtonesList.ItemSelected += async (sender, e) => {
                //await DisplayAlert("Tapped!", e.SelectedItem + " was tapped.", "OK");
                gino = (string)e.SelectedItem;

                //await DisplayAlert("Funzia!", gino, "siiii");
                await Navigation.PushAsync(new tabbedMainPage(gino));
            };
            StackLayout content = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            content.Children.Add(ringtonesList);

            Label title = new Label
            {
                Text = "Ringtones",
                TextColor = Color.Gray,
                FontSize = 32,
                

            };

            StackLayout header = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            header.Children.Add(title);

            this.Content = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                Children =
                {
                    header,
                   content,
                }
            };

        }

    }
}
