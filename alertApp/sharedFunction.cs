using System;

using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;

public class sharedFunction
{
	public sharedFunction()
	{
#if __ANDROID__
        Intent intent = new Intent(RingtoneManager.ActionRingtonePicker);
        intent.PutExtra(RingtoneManager.ExtraRingtoneTitle, "Select ringtone for notifications:");
        intent.PutExtra(RingtoneManager.ExtraRingtoneShowSilent, false);
        intent.PutExtra(RingtoneManager.ExtraRingtoneShowDefault, true);
        //intent.PutExtra(RingtoneManager.ExtraRingtoneType, RingtoneManager.TYPE_RINGTONE);
        intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
        Activity activity = new Activity();
        activity.StartActivityForResult(intent, 0);
#endif
    }
}
