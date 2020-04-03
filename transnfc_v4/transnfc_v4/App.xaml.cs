using System;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace transnfc_v4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string[] keys = new string[] { "id", "email", "login", "pwd", "first", "last" };
            if (Array.TrueForAll(keys, new Predicate<string>(key =>
                Current.Properties.ContainsKey(key))))
            {
                MainPage = new View.Master();
            }
            else
            {
                MainPage = new View.Login();
            }
        }
    }
}
