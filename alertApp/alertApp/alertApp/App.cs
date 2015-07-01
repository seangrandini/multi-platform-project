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
#if __ANDROID__
            if (sharedLogic.database.IsEmpty())
            {
                sharedLogic.settings = new Item();
                sharedLogic.settings.ID = 1;
                sharedLogic.settings.Name = "settings";
                sharedLogic.settings.setUriAsProperty(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
                sharedLogic.database.SaveItem(sharedLogic.settings);
            }
            //sharedLogic.settings.defaultUri = sharedLogic.database.GetItem(1).defaultUri;
            sharedLogic.settings.setSettingsFromItem(sharedLogic.database.GetItem(1));
            sharedLogic.defaultSong = sharedLogic.settings.derivateUri();
            if (sharedLogic.defaultSong == null)
            {
                sharedLogic.defaultSong = RingtoneManager.GetDefaultUri(RingtoneType.Alarm);
            }
#endif
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
