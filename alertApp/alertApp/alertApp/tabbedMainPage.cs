using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
namespace alertApp
{
    class tabbedMainPage : TabbedPage     
    {
        public tabbedMainPage(string s)
        {
			NavigationPage.SetHasNavigationBar(this, false);
			this.Children.Add(new settingsPage(s) { Title = "Settings" });
            this.Children.Add(new mainPage() { Title = "Home" });

		}
        public tabbedMainPage()
        {
			NavigationPage.SetHasNavigationBar(this, false);
			mainPage myMainPage = new mainPage() { Title = "Home" };
            this.Children.Add(myMainPage);
            this.Children.Add(new settingsPage() { Title = "Settings" });
		}
    }
}
