using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Networking.PushNotifications;
using System.Diagnostics;
using System.Text;

using Microsoft.Phone.Notification;
using Microsoft.WindowsAzure.Messaging;
using Windows.ApplicationModel.Background;

namespace alertApp.WinPhone
{
	public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
	{
		public MainPage ()
		{

			InitializeComponent ();
			SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

			global::Xamarin.Forms.Forms.Init ();
			LoadApplication (new alertApp.App ());

			var channel = HttpNotificationChannel.Find("ProgelOsmAlertingChannel");
			if (channel == null)
			{
				channel = new HttpNotificationChannel("ProgelOsmAlertingChannel");
				channel.Open();
				//channel.BindToShellToast();
			}

			channel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(async (o, args) =>
			{
				var hub = new NotificationHub("alarmapp", "Endpoint=sb://alarmapp-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=KIZ6Tt3zZ27QA5Yu5X8QKpRRd/MgZ8u2b2ShyPw/R8s=");
				await hub.RegisterNativeAsync(args.ChannelUri.ToString());
			});
			channel.HttpNotificationReceived += Channel_HttpNotificationReceived;
			channel.ShellToastNotificationReceived += Channel_ShellToastNotificationReceived;

			var taskRegistered = false;
			var exampleTaskName = "RawNotificationBackgroundTask";

			foreach (var task in BackgroundTaskRegistration.AllTasks)
			{
				if (task.Value.Name == exampleTaskName)
				{
					taskRegistered = true;
					break;
				}
			}

			if (!taskRegistered)
			{

				var builder = new BackgroundTaskBuilder();

				builder.Name = exampleTaskName;
				builder.TaskEntryPoint = "alertApp.BackgroundTask.BackgroundTask";
				builder.SetTrigger(new PushNotificationTrigger());
				BackgroundTaskRegistration task = builder.Register();
			}

		}

		public void Channel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
		{
			StringBuilder message = new StringBuilder();
			string relativeUri = string.Empty;

			message.AppendFormat("Received Toast {0}:\n", DateTime.Now.ToShortTimeString());

			// Parse out the information that was part of the message.
			foreach (string key in e.Collection.Keys)
			{
				message.AppendFormat("{0}: {1}\n", key, e.Collection[key]);

				if (string.Compare(
					key,
					"wp:Param",
					System.Globalization.CultureInfo.InvariantCulture,
					System.Globalization.CompareOptions.IgnoreCase) == 0)
				{
					relativeUri = e.Collection[key];
				}
			}

			// Display a dialog of all the fields in the toast.
			Dispatcher.BeginInvoke(() => MessageBox.Show(message.ToString()));
		}

		private void Channel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
		{
			StringBuilder message = new StringBuilder();
			string relativeUri = string.Empty;
		}

	}

}