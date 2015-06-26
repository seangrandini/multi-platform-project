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

using Android.Content;
using System.Diagnostics;
namespace alertApp.Droid
{


    [Activity(Label = "alertApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {

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
                        string ringtoneJLO = (string)intent.GetParcelableExtra(RingtoneManager.ExtraRingtonePickedUri);
                        Uri t = new Uri(ringtoneJLO);
                        sharedLogic.defaultSong = t;
                        //Uri ringtone = (Uri)ringtoneJLO;

                        // Toast.makeText(getBaseContext(),RingtoneManager.URI_COLUMN_INDEX,
                        // Toast.LENGTH_SHORT).show();
                        break;

                    default:
                        break;
                }
            }

        }


    }
}

