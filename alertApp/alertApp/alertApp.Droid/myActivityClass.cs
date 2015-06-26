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

namespace alertApp.Droid
{
    public class myActivityClass: Activity
    {
        public myActivityClass() : base()
        {   
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
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