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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(transnfc_v4.UIElements.Button), typeof(transnfc_v4.Droid.Renderers.Button))]
namespace transnfc_v4.Droid.Renderers
{
    class Button : ButtonRenderer
    { 
        public Button(Context ctx) : base(ctx) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                switch ((e.NewElement as transnfc_v4.UIElements.Button).TextAlignment)
                {
                    case Xamarin.Forms.TextAlignment.Start:
                        Control.Gravity = GravityFlags.Start;
                        return;
                    case Xamarin.Forms.TextAlignment.Center:
                        Control.Gravity = GravityFlags.Center;
                        return;
                    case Xamarin.Forms.TextAlignment.End:
                        Control.Gravity = GravityFlags.End;
                        return;
                }
            }
        }
    }
}