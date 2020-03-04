using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace transnfc_v4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new View.Master();
        }
    }
}
