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
            //intent.PutExtra(RingtoneManager.ExtraRingtoneType, 1);
            intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
            //System.Diagnostics.Debug.WriteLine("qui......................................................................................................................");
            //((Activity)Forms.Context).
            /*myActivityClass newActivity = new myActivityClass();
            newActivity.StartActivityForResult(intent, 0);*/
            ((Activity)Forms.Context).StartActivityForResult(intent, 0);
        }
        /*protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            if (resultCode == Result.Ok)
            {
                switch (requestCode)
                {
                    case 0:
                        string ringtoneJLO = (string)intent.GetParcelableExtra(RingtoneManager.ExtraRingtonePickedUri);
                        Uri t = new Uri(ringtoneJLO);
                        //Uri ringtone = (Uri)ringtoneJLO;

                        // Toast.makeText(getBaseContext(),RingtoneManager.URI_COLUMN_INDEX,
                        // Toast.LENGTH_SHORT).show();
                        break;

                    default:
                        break;
                }
            }

        }*/
    }
}