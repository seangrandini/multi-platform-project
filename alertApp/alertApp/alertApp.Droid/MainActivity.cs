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

using System.Diagnostics;
namespace alertApp.Droid
{


    [Activity (Label = "alertApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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

        protected override void OnCreate (Bundle bundle)
		{
            instance = this;

            base.OnCreate (bundle);

            global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new alertApp.App ());

            RegisterWithGCM();

        }
        protected override void OnResume()
        {
            base.OnResume();


            if (sharedLogic.isPlaying)
            {
                System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAdddddddddddddddddd");
                androidAudio.StopSound();
            }
        }
    }
}

