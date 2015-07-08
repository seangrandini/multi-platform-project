using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Gcm.Client;
using Android.Media;

using Android.Net;
using Android.Content;
using System.Diagnostics;
using System.Timers;
using Android.Telephony;

namespace alertApp.Droid
{

    [Activity(Label = "alertApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public static Timer timer;
        public static DateTime lastDateTime;
        public static int timeOut = 600000;
        public static NetworkStateReceiver receiver = new NetworkStateReceiver();

        public static MainActivity instance;
        private void RegisterWithGCM()
        {
            // Check to ensure everything's setup right
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);

            // Register for push notifications
            GcmClient.Register(this, Constants.SenderID);
        }

        protected override void OnCreate(Bundle bundle)
        {
			instance = this;


			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new alertApp.App());

			RegisterWithGCM();

            androidVariable.currentActivity = this;

			checkConnection();

			timer = new Timer(timeOut);
            timer.Elapsed += onTimeOut;
            timer.AutoReset = true;
            timer.Enabled = true;
            
        }
        protected override void OnResume()
        {
            base.OnResume();

            if (sharedLogic.isPlaying == 1)
            {
                androidAudio.StopSound();
            }
            sharedLogic.isPlaying = 2;
        }
        protected override void OnPause()
        {
            base.OnPause();

            sharedLogic.isPlaying = 0;
        }
        public void LaunchActivityForResult()
        {
            Intent intent = new Intent(RingtoneManager.ActionRingtonePicker);
            intent.PutExtra(RingtoneManager.ExtraRingtoneTitle, "Select ringtone for notifications:");
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowSilent, false);
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowDefault, true);
            //intent.PutExtra(RingtoneManager.ExtraRingtoneType, 1);
            intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
            this.StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            if (resultCode == Result.Ok)
            {
                switch (requestCode)
                {
                    case 0:
                        Android.Net.Uri ring = (Android.Net.Uri)intent.GetParcelableExtra(RingtoneManager.ExtraRingtonePickedUri);
                        sharedLogic.defaultSong = sharedLogic.uriToBuilderAndroid(ring).Build();
                        sharedLogic.settings.setSettingsFromItem(sharedLogic.database.GetItem(1));
                        sharedLogic.settings.setUriAsProperty(ring);
                        sharedLogic.database.SaveItem(sharedLogic.settings);
                        break;

                    default:
                        break;
                }
            }

        }

        public void onTimeOut(Object source, ElapsedEventArgs e)
        {
            checkConnection();
        }

        public void checkConnection()
        {
            receiver.OnReceive(this, this.Intent);
			if (CallStatus())
			{
				if (sharedLogic.isPlaying != 2)
				{

					if (sharedLogic.defaultSong != null)
					{
						androidAudio.PlaySound(this, sharedLogic.defaultSong);
						//song = Android.Net.Uri.Builder;
					}
					else
					{
						androidAudio.PlaySound(this, RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));
					}

				}
				NetworkStateReceiver.createNotification("Network operator is null", "Probably there's no call capibility", this, this.Intent);
			}
        }
		public bool CallStatus()
		{
			TelephonyManager tm = (TelephonyManager)this.GetSystemService(Context.TelephonyService);
			if (tm.NetworkOperator != null)
			{
				return true;
			}
			else
			{
				return false;
			}
        }

	}
}

