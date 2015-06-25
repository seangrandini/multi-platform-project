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
                Text = "Alarm App"
            };
            Button alarmSettings = new Button
            {
                Text = "Impostazioni allarme"
            };
            alarmSettings.Clicked += (sender, args) =>
            {
                count++;
                title.Text = "Alarm App " + count;
            };
        }
    }
}
