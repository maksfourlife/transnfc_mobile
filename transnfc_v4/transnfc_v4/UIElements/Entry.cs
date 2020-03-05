using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace transnfc_v4.UIElements
{
    public class Entry : Xamarin.Forms.Entry
    {
        public static BindableProperty UnderlineProperty = BindableProperty.Create("Underline", typeof(UnderlineDisplay), typeof(Entry), default(UnderlineDisplay));
        
        public UnderlineDisplay Underline
        {
            get { return (UnderlineDisplay)GetValue(UnderlineProperty); }
            set { SetValue(UnderlineProperty, value); }
        }

        public enum UnderlineDisplay
        {
            Hidden,
            Normal
        }
    }
}
