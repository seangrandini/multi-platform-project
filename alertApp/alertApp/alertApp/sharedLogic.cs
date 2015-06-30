using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Android.Media;
namespace alertApp
{
    class sharedLogic
    {
        public static int isPlaying;
        public static string defaultSong;
        public static Item settings;
        public static ItemDatabase database;
        public static string getDefaultSongNameAndroid()
        {
            if (defaultSong != "")
            {
                Android.Net.Uri.Builder builder = new Android.Net.Uri.Builder();
                builder.Path(sharedLogic.defaultSong);
                Android.Net.Uri songa = builder.Build();
                Ringtone ringtone = RingtoneManager.GetRingtone(Forms.Context, songa);
                String songName = ringtone.GetTitle(Forms.Context);
                return songName;
            }
            else
            {
                return "Default";
            }
        }
        public static Android.Net.Uri getDefaultSongUriAndroid()
        {
            if (defaultSong != "")
            {
                Android.Net.Uri.Builder builder = new Android.Net.Uri.Builder();
                builder.Path(sharedLogic.defaultSong);
                Android.Net.Uri songa = builder.Build();
                return songa;
            }
            else
            {
                return RingtoneManager.GetDefaultUri(RingtoneType.Ringtone);
            }
        }
    }
    //class ringtone
    //{
    //    private Uri uri;
    //    public ringtone(Uri uri)
    //    {
    //        this.uri = uri;
    //    }
    //}
}
