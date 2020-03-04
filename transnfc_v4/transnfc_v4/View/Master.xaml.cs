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

            BindingContext = new ViewModel.Master(NewPageSelected);

            SetPage(new Main());
        }

        void NewPageSelected(string page_name)
        {
            switch (page_name)
            {
                case "Main":
                    SetPage(new Main());
                    return;
                case "Wallet":
                    SetPage(new Wallet());
                    return;
                case "Settings":
                    SetPage(new Settings());
                    return;
                case "Feedback":
                    SetPage(new Feedback());
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        void SetPage(Page page)
        {
            Detail = new NavigationPage(page)
            {
                BarBackgroundColor = (Color)Application.Current.Resources["blue1"],
            };
            IsPresented = false;
        }
    }
}