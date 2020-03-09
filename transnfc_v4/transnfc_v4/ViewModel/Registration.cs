using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace transnfc_v4.ViewModel
{
    class Registration
    {
        public Registration()
        {
            GoToLogin = new Command(() =>
            {
                Application.Current.MainPage = new View.Login();
            });
        }

        public ICommand GoToLogin { get; private set; }
    }
}
