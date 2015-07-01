using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;
#if __ANDROID__
using Android.Media;
#endif

namespace alertApp
{
	public class App : Application
	{
        //static ItemDatabase database;
        public App ()
		{
            // The root page of your application
            sharedLogic.database = new ItemDatabase();
            Item settings = new Item();
            sharedLogic.database = new ItemDatabase();
            sharedLogic.settings = new Item();
            DependencyService.Get<IActivityInterface>().DatabaseConstructor();
            MainPage = new tabbedMainPage();

        }
        public static ItemDatabase Database 
        {
            get
            {
                return sharedLogic.database;
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
