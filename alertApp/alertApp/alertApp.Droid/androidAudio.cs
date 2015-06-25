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
    class androidAudio
    {
        public static MediaPlayer player;
        public static void PlaySound(Context context, Android.Net.Uri uri)
        {
            if (!sharedLogic.isPlaying)
            { 
                sharedLogic.isPlaying = true;
                player = MediaPlayer.Create(context, uri);
                player.Start();
            }
        }
        public static void StopSound()
        {
            player.Stop();
            sharedLogic.isPlaying = false;
        }
        /*public static MediaPlayer player;
        public static void StartPlayer(String filePath)
        {
            sharedLogic.isPlaying = true;
            if (player == null)
            {
                player = new MediaPlayer();
            }
            else
            {
                player.Reset();
                player.SetDataSource(filePath);
                player.Prepare();
                player.Start();
            }
        }*/
        //public static androidAudio incomingNotification;

    }
}