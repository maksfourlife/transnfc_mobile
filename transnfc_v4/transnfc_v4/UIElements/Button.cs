using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace transnfc_v4.UIElements
{
    public class Button : Xamarin.Forms.Button
    {
        public static readonly BindableProperty TextAlignmentProperty = BindableProperty.Create("TextAlignment", typeof(TextAlignment), typeof(Button), TextAlignment.Center);

        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }
    }
}
