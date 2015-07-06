using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace alertApp
{
    class ringtoneCell : ViewCell
    {
        public ringtoneCell()
        {
            StackLayout nameLayout = CreateNameLayout();
            Image image = CreateRingtoneImageLayout;

            StackLayout viewLayout = new StackLayout
            {
                Padding = 10,
                Orientation = StackOrientation.Horizontal,
                Children = { image, nameLayout }
            };
            View = viewLayout;
        }

        /// <summary>
        ///   Create a Xamarin.Forms image and bind it to the ImageUri property.
        /// </summary>
        /// <value>The create employee image layout.</value>
        static Image CreateRingtoneImageLayout
        {
            get
            {
                Image image = new Image
                {
                    HorizontalOptions = LayoutOptions.Start
                };
                image.SetBinding(Image.SourceProperty, new Binding("ImageP"));
                image.WidthRequest = image.HeightRequest = 40;
                return image;
            }

        }



            /// <summary>
            ///   Create a layout to hold the name of the ringtone.
            /// </summary>
            /// <returns>The name layout.</returns>
        static StackLayout CreateNameLayout()
        {
            #region Create a Label for name
            Label nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");
            #endregion

            StackLayout nameLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { nameLabel }
            };
            return nameLayout;
        }

            //    var image = new Image
            //    {
            //        HorizontalOptions = LayoutOptions.Start,
            //    };
            //    image.SetBinding(Image.SourceProperty, new Binding("Toolkit.Content/play.png"));

            //    var nameLayout = CreateNameLayout();

            //    var viewLayout = new StackLayout()
            //    {
            //        Orientation = StackOrientation.Horizontal,
            //        Children = { image, nameLayout }

            //    };
            //    //List<ringtoneCell> myListOfEmployeeObjects = GetAListOfAllEmployees();
            //    //var listView = new ListView
            //    //{
            //    //    RowHeight = 40,
            //    //};
            //    //listView.ItemsSource = myListOfEmployeeObjects;
            //    //listView.ItemTemplate = new DataTemplate(typeof(ringtoneCell));

            //    //View = viewLayout;

            //}

            //static StackLayout CreateNameLayout()
            //{
            //    var nameLabel = new Label
            //    {
            //        HorizontalOptions = LayoutOptions.FillAndExpand
            //    };
            //    nameLabel.SetBinding(Label.TextProperty, "Kick in Rock");

            //    var nameLayout = new StackLayout()
            //    {
            //        HorizontalOptions = LayoutOptions.StartAndExpand,
            //        Orientation = StackOrientation.Vertical,
            //        Children = { nameLabel }


            //    };
            //    return nameLayout;
    }

}


