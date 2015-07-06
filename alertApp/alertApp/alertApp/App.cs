using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;
#if __ANDROID__
using Android.Media;
#endif
using System.Collections.ObjectModel;
using alertApp;

namespace alertApp
{
    public class App : Application
    {
        //static ItemDatabase database;
        public App()
        {
            // The root page of your application
            sharedLogic.database = new ItemDatabase();
            Item settings = new Item();

			sharedLogic.notificationDatabase = new NotificationItemDatabase();
			NotificationItem singleNotification = new NotificationItem();

			sharedLogic.notificationDatabase = new NotificationItemDatabase();

            sharedLogic.database = new ItemDatabase();
            sharedLogic.settings = new Item();

			if (sharedLogic.notificationDatabase.IsEmpty())
			{
				singleNotification.ID = 1;
				singleNotification.Title = "0 notification";
				singleNotification.Text = "";
				singleNotification.Name = "notification";
				sharedLogic.notificationDatabase.SaveItem(singleNotification);
				sharedLogic.notifications.Append(singleNotification.Title, singleNotification.Text);
			}
			else
			{
				sharedLogic.notifications = new NotificationHistory();
				for (int i = 1; i <= sharedLogic.notificationDatabase.length(); i++)
				{
					singleNotification = sharedLogic.notificationDatabase.GetItem(i);
					sharedLogic.notifications.Append(singleNotification.Title, singleNotification.Text);
					System.Diagnostics.Debug.WriteLine(sharedLogic.notifications.notifactionList[i-1].Title);
				}
			}

            DependencyService.Get<IActivityInterface>().DatabaseConstructor();

            MainPage = new NavigationPage (new tabbedMainPage());

        }
            static ObservableCollection<Ringtone> _ringtones;
        
            public static ObservableCollection<Ringtone> Ringtones
            {
                get
                {
                    List<Ringtone> list = new List<Ringtone>
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
                    int counter = 1;
                    _ringtones = new ObservableCollection<Ringtone>(list.OrderBy(e => e.Name));
                    return _ringtones;
                }
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
