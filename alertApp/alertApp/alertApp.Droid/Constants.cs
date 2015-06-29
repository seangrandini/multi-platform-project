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

namespace alertApp.Droid
{     
    class Constants
    {
        public const string SenderID = "177791980289"; // Google API Project Number
        public const string ListenConnectionString = "Endpoint=sb://alarmapp-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=KIZ6Tt3zZ27QA5Yu5X8QKpRRd/MgZ8u2b2ShyPw/R8s=";
        public const string NotificationHubName = "alarmapp";
    }
}