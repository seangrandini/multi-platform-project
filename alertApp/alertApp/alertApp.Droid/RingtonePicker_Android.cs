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

using Android.Media;
using Xamarin.Forms;
namespace alertApp.Droid
{
    public class RingtonePicker_Android : Java.Lang.Object, IRingtonePicker
    {
        public RingtonePicker_Android() { }

        public void RingtonePicker()
        {
            System.Diagnostics.Debug.WriteLine("qui ci siamo..................................................................................................");
            Intent intent = new Intent(RingtoneManager.ActionRingtonePicker);
            intent.PutExtra(RingtoneManager.ExtraRingtoneTitle, "Select ringtone for notifications:");
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowSilent, false);
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowDefault, true);
            //intent.PutExtra(RingtoneManager.ExtraRingtoneType, RingtoneManager.TYPE_RINGTONE);
            intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
            Activity activity = new Activity();
            activity.StartActivityForResult(intent, 0);
        }
    }
}