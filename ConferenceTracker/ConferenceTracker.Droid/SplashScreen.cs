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
using Android.Support.V7.App;
using Android.Content.PM;
using System.Threading.Tasks;

namespace ConferenceTracker.Droid
{
    [Activity(
         MainLauncher = true
        , Icon = "@drawable/logo_icon"
        , Theme = "@style/MyTheme"
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            Task startup = new Task(() => { Task.Delay(2000); });

            startup.ContinueWith(t => {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startup.Start();
        }

    }
}