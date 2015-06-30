using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Resources;

using Android.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Gcm.Client;
using WindowsAzure.Messaging;
using Android.Media;

[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

//GET_ACCOUNTS is only needed for android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace alertApp.Droid
{

    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE },
    Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK },
    Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY },
    Categories = new string[] { "@PACKAGE_NAME@" })]
    public class MyBroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] SENDER_IDS = new string[] { Constants.SenderID };

        public const string TAG = "MyBroadcastReceiver-GCM";
    }

    [Service] // Must use the service tag
    public class PushHandlerService : GcmServiceBase
    {
        public static string RegistrationID { get; private set; }
        private NotificationHub Hub { get; set; }

        public PushHandlerService() : base(Constants.SenderID)
        {
            Log.Info(MyBroadcastReceiver.TAG, "PushHandlerService() constructor");
        }
        protected override void OnRegistered(Context context, string registrationId)
        {
            Log.Verbose(MyBroadcastReceiver.TAG, "GCM Registered: " + registrationId);
            RegistrationID = registrationId;

            //createNotification("PushHandlerService-GCM Registered...","The device has been Registered!");

            Hub = new NotificationHub(Constants.NotificationHubName, Constants.ListenConnectionString,
                                        context);
            try
            {
                Hub.UnregisterAll(registrationId);
            }
            catch (Exception ex)
            {
                Log.Error(MyBroadcastReceiver.TAG, ex.Message);
            }

            //var tags = new List<string>() { "falcons" }; // create tags if you want
            var tags = new List<string>() { };

            try
            {
                var hubRegistration = Hub.Register(registrationId, tags.ToArray());
            }
            catch (Exception ex)
            {
                Log.Error(MyBroadcastReceiver.TAG, ex.Message);
            }
        }

        protected override void OnMessage(Context context, Intent intent)
        {
            Log.Info(MyBroadcastReceiver.TAG, "GCM Message Received!");

            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }

            string messageText = intent.Extras.GetString("message");
            if (!string.IsNullOrEmpty(messageText))
            {
                createNotification("New hub message!", messageText);
            }
            else
            {
                createNotification("Unknown message details", msg.ToString());
            }
            if (sharedLogic.isPlaying != 2)
            {
                
                if (sharedLogic.defaultSong != "")
                {
                    androidAudio.PlaySound(this, sharedLogic.getDefaultSongUriAndroid());
                    //song = Android.Net.Uri.Builder;
                }
                else
                {
                    androidAudio.PlaySound(this, RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));
                }
            }
            /*androidAudio.incomingNotification = new androidAudio();
            androidAudio.incomingNotification.StartPlayer(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone).Path);*/
        }

        void createNotification(string title, string desc)
        {
            //my create notification
            //Creazione Intent
            Intent myIntent = new Intent(this, typeof(MainActivity));

            PendingIntent myPendingIntent = PendingIntent.GetActivity(this, 0, myIntent, PendingIntentFlags.UpdateCurrent);
            //Creazione notifica
            Notification.Builder myBuilder = new Notification.Builder(this)
            .SetContentIntent(myPendingIntent)
            .SetContentTitle(title)
            .SetContentText(desc)
            /*.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)*/
            .SetAutoCancel(true)
            .SetSmallIcon(Android.Resource.Drawable.SymActionEmail);

            Notification myNotification = myBuilder.Build();

            NotificationManager myNotificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            myNotificationManager.Notify(1, myNotification);
        }

        protected void dialogNotify(String title, String message)
        {

            MainActivity.instance.RunOnUiThread(() => {
                AlertDialog.Builder dlg = new AlertDialog.Builder(MainActivity.instance);
                AlertDialog alert = dlg.Create();
                alert.SetTitle(title);
                alert.SetButton("Ok", delegate {
                    alert.Dismiss();
                });
                alert.SetMessage(message);
                alert.Show();
            });
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {
            Log.Verbose(MyBroadcastReceiver.TAG, "GCM Unregistered: " + registrationId);

            createNotification("GCM Unregistered...", "The device has been unregistered!");
        }

        protected override bool OnRecoverableError(Context context, string errorId)
        {
            Log.Warn(MyBroadcastReceiver.TAG, "Recoverable Error: " + errorId);

            return base.OnRecoverableError(context, errorId);
        }

        protected override void OnError(Context context, string errorId)
        {
            Log.Error(MyBroadcastReceiver.TAG, "GCM Error: " + errorId);
        }
    }
}