using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace alertApp.WinPhone81
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
		//private string exampleTaskName = "RawPushNotificationBackgroundTask";
		public MainPage()
        {
            this.InitializeComponent();
			// add this line
			LoadApplication(new alertApp.App());

			this.NavigationCacheMode = NavigationCacheMode.Required;

			var exampleTaskName = "RawPushNotificationBackgroundTask";
			var taskRegistered = false;

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
				builder.SetTrigger(new Windows.ApplicationModel.Background.PushNotificationTrigger());
				try
				{
					BackgroundTaskRegistration task = builder.Register();
				}
				catch
				{

				}
			}


		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
        {
			// TODO: Prepare page for display here.

			// TODO: If your application contains multiple pages, ensure that you are
			// handling the hardware Back button by registering for the
			// Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
			// If you are using the NavigationHelper provided by some templates,
			// this event is handled for you.
		}
		/*private bool checkBgTask()
		{
			var taskRegistered = false;

			foreach (var task in BackgroundTaskRegistration.AllTasks)
			{
				if (task.Value.Name == exampleTaskName)
				{
					taskRegistered = true;
					break;
				}
			}

			return taskRegistered;
		}

		private BackgroundTaskBuilder createTask()
		{
			var builder = new BackgroundTaskBuilder();

			builder.Name = exampleTaskName;
			builder.TaskEntryPoint = "alertApp.BackgroundTask.BackgroundTask";
			builder.SetTrigger(new Windows.ApplicationModel.Background.PushNotificationTrigger());

			return builder;

		}*/
	}
}
