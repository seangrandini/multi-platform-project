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
        //static ItemDatabase database;
        public App ()
		{
            // The root page of your application
            //database = new ItemDatabase();
            //Item settings = new Item();
            sharedLogic.database = new ItemDatabase();
            sharedLogic.settings = new Item();
            if (sharedLogic.database.IsEmpty())
            {
                sharedLogic.settings = new Item();
                sharedLogic.settings.ID = 1;
                sharedLogic.settings.Name = "settings";
                sharedLogic.settings.defaultUri = "";
                sharedLogic.database.SaveItem(sharedLogic.settings);
            }
            //sharedLogic.settings.defaultUri = sharedLogic.database.GetItem(1).defaultUri;
            sharedLogic.settings.setSettingsFromItem(sharedLogic.database.GetItem(1));
            sharedLogic.defaultSong = sharedLogic.settings.defaultUri;
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
