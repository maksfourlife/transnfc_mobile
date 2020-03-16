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

            if (Current.Properties.ContainsKey("id") &&
               Current.Properties.ContainsKey("email") &&
                Current.Properties.ContainsKey("login") &&
                Current.Properties.ContainsKey("pwd") &&
                Current.Properties.ContainsKey("first") &&
                Current.Properties.ContainsKey("last"))
                MainPage = new View.Master();
            else
                MainPage = new View.Login();
        }
    }
}
