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

using alertApp.Droid;
using Android.Media;
using Xamarin.Forms;
using Android.Content.PM;
using Android.Util;
using System.Diagnostics;
[assembly: Dependency(typeof(RingtonePicker_Android))]

namespace alertApp.Droid
{
    public class RingtonePicker_Android : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, IActivityInterface
    {
        public RingtonePicker_Android() { }


        public void RingtonePicker()
        {
            Intent intent = new Intent(RingtoneManager.ActionRingtonePicker);
            intent.PutExtra(RingtoneManager.ExtraRingtoneTitle, "Select ringtone for notifications:");
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowSilent, false);
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowDefault, true);
            intent.PutExtra(RingtoneManager.ExtraRingtoneType, "TYPE_ALL");
            intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, sharedLogic.getDefaultSongUriAndroid());
            ((Activity)Forms.Context).StartActivityForResult(intent, 0);
        }
    }
}