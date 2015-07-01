using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
#if __ANDROID__
using Android.Media;
#endif
namespace alertApp
{
    class sharedLogic
    {
        public static int isPlaying;
        //public static string defaultSong;
        public static Item settings;
        public static ItemDatabase database;

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
