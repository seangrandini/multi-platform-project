using System;
using System.Collections.Generic;
using System.Text;

using alertApp;
using Xamarin.Forms;
#if __ANDROID__
using Android.Media;
#endif
namespace alertApp
{
    class sharedLogic
    {
        public static int isPlaying;
		public static int internetStatus;

        public static Item settings;
        public static ItemDatabase database;

		public static int notificationSaveNumber;
		public static NotificationHistory notifications;

		public static void UpDateListView()
		{

		}
		public static void UpDateInternetStatus(int tempInternetStatus)
		{
			sharedLogic.internetStatus = tempInternetStatus;
			if (sharedLogic.internetStatus != null)
			{
				if (sharedLogic.internetStatus == 0)
				{
					mainPage.status.Text = "Status: Disconnected " + DateTime.Now;
					mainPage.footer.BackgroundColor = Color.FromRgb(255,0,0);
				}
				else if (sharedLogic.internetStatus == 1)
				{
					mainPage.status.Text = "Status: Connected " + DateTime.Now;
					mainPage.footer.BackgroundColor = Color.FromRgb(106, 196, 49);
				}
			}
		}
#if __ANDROID__
        public static Android.Net.Uri defaultSong;

        public static Android.Net.Uri.Builder uriToBuilderAndroid(Android.Net.Uri ring)
        {
            Android.Net.Uri.Builder builder = new Android.Net.Uri.Builder();
            builder.Authority(ring.Authority);
            builder.EncodedAuthority(ring.EncodedAuthority);
            builder.EncodedFragment(ring.EncodedFragment);
            builder.EncodedPath(ring.EncodedPath);
            builder.EncodedQuery(ring.EncodedQuery);
            builder.Fragment(ring.Fragment);
            builder.Path(ring.Path);
            builder.Query(ring.Query);
            builder.Scheme(ring.Scheme);

            return builder;
        }
#endif

    }
}
