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
using alertApp.Droid;
using Android.Media;
using Xamarin.Forms;
using Android.Content.PM;
using Android.Util;
using System.Diagnostics;

[assembly: Dependency(typeof(ActivityInterface_Android))]

namespace alertApp.Droid
{
    public class ActivityInterface_Android : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, IActivityInterface
    {
        public ActivityInterface_Android() { }


        public void RingtonePicker()
        {
            Intent intent = new Intent(RingtoneManager.ActionRingtonePicker);
            intent.PutExtra(RingtoneManager.ExtraRingtoneTitle, "Select ringtone for notifications:");
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowSilent, false);
            intent.PutExtra(RingtoneManager.ExtraRingtoneShowDefault, true);
            intent.PutExtra(RingtoneManager.ExtraRingtoneType, "TYPE_ALL");
            intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, sharedLogic.defaultSong);
            ((Activity)Forms.Context).StartActivityForResult(intent, 0);
        }
        public void DatabaseConstructor()
        {
            if (sharedLogic.database.IsEmpty())
            {
                sharedLogic.settings = new Item();
                sharedLogic.settings.ID = 1;
                sharedLogic.settings.Name = "settings";
				sharedLogic.settings.notificationSaveNumber = 20;
                sharedLogic.settings.setUriAsProperty(RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
                sharedLogic.database.SaveItem(sharedLogic.settings);
            }
            //sharedLogic.settings.defaultUri = sharedLogic.database.GetItem(1).defaultUri;
            sharedLogic.settings.setSettingsFromItem(sharedLogic.database.GetItem(1));
            sharedLogic.defaultSong = sharedLogic.settings.derivateUri();
            if (sharedLogic.defaultSong == null)
            {
                sharedLogic.defaultSong = RingtoneManager.GetDefaultUri(RingtoneType.Alarm);
            }
			sharedLogic.notificationSaveNumber = sharedLogic.settings.notificationSaveNumber;
        }
    }
}