using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace transnfc_v4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();

            SetPage(new Main());
        }

        void SetPage(Page page)
        {
            Detail = new NavigationPage(page)
            {
                BarBackgroundColor = (Color)Application.Current.Resources["blue1"],
            };
        }
    }
}