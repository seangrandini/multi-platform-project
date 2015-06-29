using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
namespace alertApp
{
    class tabbedMainPage : TabbedPage     
    {
        public tabbedMainPage()
        {
            this.Children.Add(new mainPage() { Title = "Home" });
            this.Children.Add(new settingsPage() { Title = "Settings" });
        }
    }
}
