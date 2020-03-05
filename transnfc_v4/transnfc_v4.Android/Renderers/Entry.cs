using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(transnfc_v4.UIElements.Entry), typeof(transnfc_v4.Droid.Renderers.Entry))]
namespace transnfc_v4.Droid.Renderers
{
    class Entry : EntryRenderer
    {
        public Entry(Context ctx) : base(ctx) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                switch ((e.NewElement as UIElements.Entry).Underline)
                {
                    case UIElements.Entry.UnderlineDisplay.Normal:
                        GradientDrawable gd = new GradientDrawable();
                        gd.SetShape(ShapeType.Line);
                        gd.SetStroke(5, Color.FromHex("#277db6").ToAndroid());
                        ScaleDrawable sd = new ScaleDrawable(gd, GravityFlags.Bottom, 0f, 2f);
                        sd.SetLevel(7500);
                        Control.SetBackground(sd);
                        break;
                    case UIElements.Entry.UnderlineDisplay.Hidden:
                        Control.SetBackground(new GradientDrawable());
                        break;
                }
                if (!(e.NewElement as UIElements.Entry).CursorVisible)
                {
                    Control.SetCursorVisible(false);
                }
            }
        }
    }
}