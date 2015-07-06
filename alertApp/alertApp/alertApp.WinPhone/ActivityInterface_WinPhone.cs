using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Phone.Media;
using alertApp.WinPhone;
using Windows.System;
using alertApp;

[assembly: Xamarin.Forms.Dependency(typeof(ActivityInterface_WinPhone))]

namespace alertApp.WinPhone
{
    public class ActivityInterface_WinPhone: IActivityInterface
    {
        public ActivityInterface_WinPhone() { }

        public async void RingtonePicker()
        {
            //await Launcher.LaunchUriAsync("")
        }

        public void DatabaseConstructor()
        {
            System.Diagnostics.Debug.WriteLine("aaaaaa");
        }
    }
}
