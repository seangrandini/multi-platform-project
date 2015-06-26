using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace alertApp
{
    class mainPage: ContentPage
    {
        int count = 0;
        public mainPage()
        {
            Label title = new Label
            {
               Text = "Alarm App",
               XAlign = TextAlignment.Center,
               HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Button alarmSettingsButton = new Button
            {
                Text= "Impostazioni allarme"
            };
            alarmSettingsButton.Clicked += (sender, args) =>
            {
                count++;
                title.Text = "Alarm App " + count;
                DependencyService.Get<IRingtonePicker>().RingtonePicker();
                ringtoneList alarmSettingsPage = new ringtoneList();
                this.Content = alarmSettingsPage.Content;

            };
            AbsoluteLayout simpleLayout = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            AbsoluteLayout.SetLayoutFlags(alarmSettingsButton, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(alarmSettingsButton, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            simpleLayout.Children.Add(title);
            simpleLayout.Children.Add(alarmSettingsButton);

            this.Content = new StackLayout
            {
                Children =
                {
                    simpleLayout
                }

            };




        }
        //int count = 0;
        //public mainPage()
        //{
        //    Label title = new Label
        //    {
        //        Text = "Alarm App"
        //    };
        //    Button alarmSettings = new Button
        //    {
        //        Text = "Impostazioni allarme",

        //    };
        //    alarmSettings.Clicked += (sender, args) =>
        //    {
        //        count++;
        //        title.Text = "Alarm App " + count;
        //    };
        //    Content = new Grid
        //    {
        //        Children =
        //        {
        //            title,
        //            alarmSettings
        //        }
        //    };
        //}
    }
}
