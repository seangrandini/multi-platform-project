using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using alertApp.WinPhone.Resources;
using Microsoft.Phone.Notification;
using Microsoft.WindowsAzure.Messaging;
using System.Text;
using System.ServiceModel;

using System.Windows.Media;

using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Controls;

using System.Threading;

namespace alertApp.WinPhone
{
	public partial class App : Application
	{
		/// <summary>
		/// Provides easy access to the root frame of the Phone Application.
		/// </summary>
		/// <returns>The root frame of the Phone Application.</returns>
		public static PhoneApplicationFrame RootFrame { get; private set; }

		/// <summary>
		/// Constructor for the Application object.
		/// </summary>
		public App()
		{
            // Copy media to isolated storage.
            CopyToIsolatedStorage();
            // Global handler for uncaught exceptions.
            UnhandledException += Application_UnhandledException;

			// Standard XAML initialization
			InitializeComponent();

			// Phone-specific initialization
			InitializePhoneApplication();

			// Language display initialization
			InitializeLanguage();

			// Show graphics profiling information while debugging.
			if (Debugger.IsAttached)
			{
				// Display the current frame rate counters.
				Application.Current.Host.Settings.EnableFrameRateCounter = true;

				// Show the areas of the app that are being redrawn in each frame.
				//Application.Current.Host.Settings.EnableRedrawRegions = true;

				// Enable non-production analysis visualization mode,
				// which shows areas of a page that are handed off to GPU with a colored overlay.
				//Application.Current.Host.Settings.EnableCacheVisualization = true;

				// Prevent the screen from turning off while under the debugger by disabling
				// the application's idle detection.
				// Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
				// and consume battery power when the user is not using the phone.
				PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
			}

		}

		// Code to execute when the application is launching (eg, from Start)
		// This code will not execute when the application is reactivated
		private void Application_Launching(object sender, LaunchingEventArgs e)
		{
			var channel = HttpNotificationChannel.Find("MyPushChannel");
			if (channel == null)
			{
				channel = new HttpNotificationChannel("MyPushChannel");
				channel.Open();
				channel.BindToShellToast();
				channel.BindToShellTile();
			}

			channel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(async (o, args) =>
			{
				var hub = new NotificationHub("alarmapp", "Endpoint=sb://alarmapp-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=KIZ6Tt3zZ27QA5Yu5X8QKpRRd/MgZ8u2b2ShyPw/R8s=");
				await hub.RegisterNativeAsync(args.ChannelUri.ToString());
			});
			channel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(Channel_ShellToastNotificationReceived);
			MainPage.questoBgPlayer.SkipNext();
		}
		void Channel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
		{
			StringBuilder message = new StringBuilder();
			string relativeUri = string.Empty;
			
			message.AppendFormat("Received Toast {0}:\n", DateTime.Now.ToShortTimeString());
			
			// Parse out the information that was part of the message.
			foreach (string key in e.Collection.Keys)
			{
				//message.AppendFormat("{0}: {1}\n", key, e.Collection[key]);
				message.AppendFormat("{0}\n", e.Collection[key]);
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
			MainPage.questo.Dispatcher.BeginInvoke(() => MessageBox.Show(message.ToString()));
            //MessageBox.Show(message.ToString());
            // Copy media to isolated storage.
		}

		// Set the minimum version number that supports custom toast sounds
		private static Version TargetVersion = new Version(8, 0, 10492);

		// Function to determine if the current device is running the target version.
		public static bool IsTargetedVersion { get { return Environment.OSVersion.Version >= TargetVersion; } }

		// Function for setting a property value using reflection.
		private static void SetProperty(object instance, string name, object value)
		{
			var setMethod = instance.GetType().GetProperty(name).GetSetMethod();
			setMethod.Invoke(instance, new object[] { value });
		}

		public void ShowToast(bool useCustomSound, bool useWavFormat, bool doSilentToast)
		{
			ShellToast toast = new ShellToast();
			toast.Title = "[title]";
			toast.Content = "[content]";

			//If the device is running the right version and a custom sound is requested
			if ((IsTargetedVersion) && (useCustomSound))
			{
				if (useWavFormat)
				{
					//Do the reflection to get the new Sound property added to the toast
					SetProperty(toast, "Sound", new Uri("MyToastSound.wav", UriKind.RelativeOrAbsolute));
				}
				else
				{
					//Do the reflection to get the new Sound property added to the toast
					//SetProperty(toast, "Sound", new Uri("MyToastSound.mp3", UriKind.RelativeOrAbsolute));
					SetProperty(toast, "Sound", new Uri("Kick in Rock.mp3", UriKind.RelativeOrAbsolute));
				}
			}
			// For a silent toast, check the version and then set the Sound property to an empty string.
			else if ((IsTargetedVersion) && (doSilentToast))
			{
				//Do the reflection to get the new Sound property added to the toast
				SetProperty(toast, "Sound", new Uri("", UriKind.RelativeOrAbsolute));
			}


			toast.Show();
		}

		public void ShowToastWithCloudService(bool useCustomSound, bool useWavFormat, bool doSilentToast)
		{
			StringBuilder toastMessage = new StringBuilder();
			toastMessage.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?><wp:Notification xmlns:wp=\"WPNotification\"><wp:Toast>");
			toastMessage.Append("<wp:Text1>Toast Title</wp:Text1>");
			toastMessage.Append("<wp:Text2>Toast Content</wp:Text2>");
			if ((IsTargetedVersion) && (useCustomSound))
			{
				if (useWavFormat)
				{
					toastMessage.Append("<wp:Sound>MyToastSound.wav</wp:Sound>");
				}
				else
				{
					//toastMessage.Append("<wp:Sound>MyToastSound.mp3</wp:Sound>");
					toastMessage.Append("<wp:Sound>Audio/Kick in Rock.mp3</wp:Sound>");
				}
			}
			else if ((IsTargetedVersion) && (doSilentToast))
			{
				toastMessage.Append("<wp:Sound Silent=\"true\"/>");
			}
			toastMessage.Append("</wp:Toast></wp:Notification>");
		}





		// Code to execute when the application is activated (brought to foreground)
		// This code will not execute when the application is first launched
		private void Application_Activated(object sender, ActivatedEventArgs e)
		{

		}

		// Code to execute when the application is deactivated (sent to background)
		// This code will not execute when the application is closing
		private void Application_Deactivated(object sender, DeactivatedEventArgs e)
		{
		}

		// Code to execute when the application is closing (eg, user hit Back)
		// This code will not execute when the application is deactivated
		private void Application_Closing(object sender, ClosingEventArgs e)
		{
		}

		// Code to execute if a navigation fails
		private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			if (Debugger.IsAttached)
			{
				// A navigation has failed; break into the debugger
				Debugger.Break();
			}
		}

		// Code to execute on Unhandled Exceptions
		private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			if (Debugger.IsAttached)
			{
				// An unhandled exception has occurred; break into the debugger
				Debugger.Break();
			}
		}

		#region Phone application initialization

		// Avoid double-initialization
		private bool phoneApplicationInitialized = false;

		// Do not add any additional code to this method
		private void InitializePhoneApplication()
		{
			if (phoneApplicationInitialized)
				return;

			// Create the frame but don't set it as RootVisual yet; this allows the splash
			// screen to remain active until the application is ready to render.
			RootFrame = new PhoneApplicationFrame();
			RootFrame.Navigated += CompleteInitializePhoneApplication;

			// Handle navigation failures
			RootFrame.NavigationFailed += RootFrame_NavigationFailed;

			// Handle reset requests for clearing the backstack
			RootFrame.Navigated += CheckForResetNavigation;

			// Ensure we don't initialize again
			phoneApplicationInitialized = true;
		}

		// Do not add any additional code to this method
		private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
		{
			// Set the root visual to allow the application to render
			if (RootVisual != RootFrame)
				RootVisual = RootFrame;

			// Remove this handler since it is no longer needed
			RootFrame.Navigated -= CompleteInitializePhoneApplication;
		}

		private void CheckForResetNavigation(object sender, NavigationEventArgs e)
		{
			// If the app has received a 'reset' navigation, then we need to check
			// on the next navigation to see if the page stack should be reset
			if (e.NavigationMode == NavigationMode.Reset)
				RootFrame.Navigated += ClearBackStackAfterReset;
		}

		private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
		{
			// Unregister the event so it doesn't get called again
			RootFrame.Navigated -= ClearBackStackAfterReset;

			// Only clear the stack for 'new' (forward) and 'refresh' navigations
			if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
				return;

			// For UI consistency, clear the entire page stack
			while (RootFrame.RemoveBackEntry() != null)
			{
				; // do nothing
			}
		}

		#endregion

		// Initialize the app's font and flow direction as defined in its localized resource strings.
		//
		// To ensure that the font of your application is aligned with its supported languages and that the
		// FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
		// and ResourceFlowDirection should be initialized in each resx file to match these values with that
		// file's culture. For example:
		//
		// AppResources.es-ES.resx
		//    ResourceLanguage's value should be "es-ES"
		//    ResourceFlowDirection's value should be "LeftToRight"
		//
		// AppResources.ar-SA.resx
		//     ResourceLanguage's value should be "ar-SA"
		//     ResourceFlowDirection's value should be "RightToLeft"
		//
		// For more info on localizing Windows Phone apps see http://go.microsoft.com/fwlink/?LinkId=262072.
		//
		private void InitializeLanguage()
		{
			try
			{
				// Set the font to match the display language defined by the
				// ResourceLanguage resource string for each supported language.
				//
				// Fall back to the font of the neutral language if the Display
				// language of the phone is not supported.
				//
				// If a compiler error is hit then ResourceLanguage is missing from
				// the resource file.
				RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

				// Set the FlowDirection of all elements under the root frame based
				// on the ResourceFlowDirection resource string for each
				// supported language.
				//
				// If a compiler error is hit then ResourceFlowDirection is missing from
				// the resource file.
				FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
				RootFrame.FlowDirection = flow;
			}
			catch
			{
				// If an exception is caught here it is most likely due to either
				// ResourceLangauge not being correctly set to a supported language
				// code or ResourceFlowDirection is set to a value other than LeftToRight
				// or RightToLeft.

				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}

				throw;
			}
		}
        private void CopyToIsolatedStorage()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string[] files = new string[] { "Kick in Rock.mp3", "Nokia - Attraction.mp3", "Nokia - Badinerie.mp3" , "Nokia - City Bird.mp3", "Nokia - Frog.mp3", "Nokia - Hurdy Gurdy.mp3", "Nokia - Intro.mp3", "Nokia - Jumping.mp3", "Nokia - Kick.mp3", "Nokia - Knick Knack.mp3", "Nokia - Lamb.mp3", "Nokia - Low.mp3", "Nokia - Merry Xmas.mp3", "Nokia - Orient.mp3", "Nokia - Ring Ring.mp3", "Nokia - Robo N1X.mp3", "Nokia - Rocket.mp3", "Nokia - Thats It.mp3", "Nokia - The Buffoon.mp3", "Nokia - Tick Tick.mp3", "Nokia Tune 2013.mp3", "Nokia Tune V2.mp3", "Nokia Tune V3.mp3" };

                foreach (var _fileName in files)
                {
                    if (!storage.FileExists(_fileName))
                    {
                        string _filePath = "Audio/" + _fileName;
                        StreamResourceInfo resource = Application.GetResourceStream(new Uri(_filePath, UriKind.Relative));

                        using (IsolatedStorageFileStream file = storage.CreateFile(_fileName))
                        {
                            int chunkSize = 4096;
                            byte[] bytes = new byte[chunkSize];
                            int byteCount;

                            while ((byteCount = resource.Stream.Read(bytes, 0, chunkSize)) > 0)
                            {
                                file.Write(bytes, 0, byteCount);
                            }
                        }
                    }
                }
            }
        }

    }
}
