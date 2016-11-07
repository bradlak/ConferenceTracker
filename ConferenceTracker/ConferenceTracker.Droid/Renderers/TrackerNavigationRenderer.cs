using Android.App;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using ConferenceTracker.Droid.Renderers;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(TrackerNavigationRenderer))]

namespace ConferenceTracker.Droid.Renderers
{
    public class TrackerNavigationRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            RemoveAppIconFromActionBar();
        }

        void RemoveAppIconFromActionBar()
        {
            var actionBar = ((Activity)Context).ActionBar;
            actionBar.SetIcon(new ColorDrawable(Color.Transparent.ToAndroid()));
        }
    }
}