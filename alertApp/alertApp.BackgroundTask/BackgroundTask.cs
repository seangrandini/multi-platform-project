using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.ApplicationModel.Background;
using Windows.Networking.PushNotifications;
namespace alertApp.BackgroundTask
{
    public sealed class BackgroundTask : IBackgroundTask
	{
		public async void Run(IBackgroundTaskInstance taskInstance)
		{
			BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();

			RawNotification notification = (RawNotification)taskInstance.TriggerDetails;
			string content = notification.Content;

			//var result = await handleNotification();

			// ...

			_deferral.Complete();

		}
	}
}
