using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Net;
using Android.Media;

namespace alertApp.Droid
{
    public class NetworkStateReceiver : BroadcastReceiver
    {
        private static String TAG = "NetworkStateReceiver";

        public override void OnReceive(Context context, Intent intent)
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            NetworkInfo ni = connectivityManager.ActiveNetworkInfo;

            if (ni != null && ni.IsConnectedOrConnecting)
            {
                System.Diagnostics.Debug.WriteLine(TAG, "Network " + ni.TypeName + " connected");
				sharedLogic.UpDateInternetStatus(1);
			}
            else if (intent.GetBooleanExtra(ConnectivityManager.ExtraNoConnectivity, true))
            {
                System.Diagnostics.Debug.WriteLine(TAG, "There's no network connectivity");
                if (sharedLogic.isPlaying != 2)
                {

                    if (sharedLogic.defaultSong != null)
                    {
                        androidAudio.PlaySound(context, sharedLogic.defaultSong);
                        //song = Android.Net.Uri.Builder;
                    }
                    else
                    {
                        androidAudio.PlaySound(context, RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));
                    }
                        
                }
				createNotification("No internet access", "There's no more network connectivity", context, intent);
				sharedLogic.UpDateInternetStatus(0);
            }
		}


		void createNotification(string title, string desc, Context context, Intent intent)
		{
			//my create notification
			//Creazione Intent
			Intent myIntent = new Intent(context, typeof(MainActivity));

			PendingIntent myPendingIntent = PendingIntent.GetActivity(context, 0, myIntent, PendingIntentFlags.UpdateCurrent);
			//Creazione notifica
			Notification.Builder myBuilder = new Notification.Builder(context)
			.SetContentIntent(myPendingIntent)
			.SetContentTitle(title)
			.SetContentText(desc)
			/*.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)*/
			.SetAutoCancel(true)
			.SetSmallIcon(Android.Resource.Drawable.SymActionEmail);

			Notification myNotification = myBuilder.Build();

			NotificationManager myNotificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;

			myNotificationManager.Notify(1, myNotification);
		}
    }
}