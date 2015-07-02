using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.Messaging;
using Microsoft.Phone.Notification;
using System.Text;

using Microsoft.Phone.BackgroundAudio;

namespace alertApp.WinPhone
{
	public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
	{
        

        public static MainPage questo = new MainPage();
        public static BackgroundAudioPlayer questoBgPlayer;
		public MainPage ()
		{
			InitializeComponent ();
			SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

			global::Xamarin.Forms.Forms.Init ();
			LoadApplication (new alertApp.App ());
			questo = this;

            questoBgPlayer = BackgroundAudioPlayer.Instance;
            BackgroundAudioPlayer.Instance.PlayStateChanged += new EventHandler(Instance_PlayStateChanged);
        }
        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {
                case PlayState.Playing:
                    //playButton.Content = "pause";
                    break;

                case PlayState.Paused:
                case PlayState.Stopped:
                   // playButton.Content = "play";
                    break;
            }

            if (null != BackgroundAudioPlayer.Instance.Track)
            {
                /*txtCurrentTrack.Text = BackgroundAudioPlayer.Instance.Track.Title +
                                       " by " +
                                       BackgroundAudioPlayer.Instance.Track.Artist;*/
            }
        }
	}



}