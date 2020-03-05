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

[assembly: Dependency(typeof(transnfc_v4.Droid.TagScanner))]
namespace transnfc_v4.Droid
{
    class TagScanner : ITagScanner
    {
        internal static Action<byte[]> _on_result;
        public void Scan(Action<byte[]> on_result)
        {
            MainActivity._do_scanning = true;
            _on_result = on_result;
        }
    }
}