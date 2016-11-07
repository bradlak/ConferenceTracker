using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(SearchBar),typeof(ConferenceTracker.iOS.Renderers.ExtendedSearchBarRenderer))]
namespace ConferenceTracker.iOS.Renderers
{
    public class ExtendedSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName == "Text")
            {
                Control.ShowsCancelButton = false;
            }
        }
    }
}
