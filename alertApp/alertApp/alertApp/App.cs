using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;

namespace alertApp
{
	public class App : Application
	{

        static ItemDatabase database;

        public App ()
		{
            // The root page of your application
            MainPage = new mainPage();
            
		}
        public static ItemDatabase Database
        {
            get
            {
                return database;
            }
        }
		protected override void OnStart ()
		{
            // Handle when your app starts
            Debug.WriteLine("start");
		}

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            Debug.WriteLine("sleep");
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
            Debug.WriteLine("resume");
        }
    }
}
