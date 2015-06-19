using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;

namespace MultiplatformApp.Droid
{
	[Activity (Label = "MultiplatformApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
        public static MobileServiceClient MobileService = new MobileServiceClient(
        "https://multiplatform-projel-alert-app.azure-mobile.net/",
        "nCuPSLGcaWmRuMGTniktLayVcjYApu26"
        );
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new MultiplatformApp.App ());
		}
	}
}

