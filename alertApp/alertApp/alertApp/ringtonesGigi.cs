using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace alertApp
{
    class ringtonesGigi : ContentPage
    {
        class Ringtone
        {
            public Ringtone(string imageP, string name)
            {
                this.ImageP = imageP;
                this.Name = name;
            }

            public string ImageP { get; set; }
            public string Name { get; set; }
             
        };

        public ringtonesGigi()
        {
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

            List<Ringtone> rings = new List<Ringtone>
            {
                new Ringtone("Toolkit.Content/play.png","Kick in Rock"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Attraction"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Badinerie"),
                new Ringtone("Toolkit.Content/play.png","Nokia - City Bird"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Frog"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Hurdy Gurdy"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Intro"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Jumping"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Kick"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Knick Knack"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Lamb"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Low"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Merry Xmas"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Orient"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Ring Ring"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Robo N1X"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Rocket"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Thats It"),
                new Ringtone("Toolkit.Content/play.png","Nokia - The Buffoon"),
                new Ringtone("Toolkit.Content/play.png","Nokia - Tick Tick"),
                new Ringtone("Toolkit.Content/play.png","Nokia Tune 2013"),
                new Ringtone("Toolkit.Content/play.png","Nokia Tune V2"),
                new Ringtone("Toolkit.Content/play.png","Nokia Tune V3"),

            };

            ListView listview = new ListView
            {
                RowHeight = 50,
                ItemsSource = rings,
                ItemTemplate = new DataTemplate(() =>
                {
                    var image = new Image();
                        image.SetBinding(Image.SourceProperty, "ImageP");
                    Label namelabel = new Label();
                    {
                        namelabel.SetBinding(Label.TextProperty, "Name");
                    }

                        

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = 0,
                            Orientation = StackOrientation.Vertical,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Children =
                            {
                                namelabel,
                                new StackLayout
                                {
                                    Children =
                                    {
                                        image,
                                    }
                                }
                            }
                        }
                    };

                })
            };

            this.Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,

                Children =
                {
                    title,
                    listview,
                }
            };
        }
    }
}
