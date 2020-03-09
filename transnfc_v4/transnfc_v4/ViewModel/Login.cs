using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace transnfc_v4.ViewModel
{
    class Login
    {
        public Login()
        {
            GoToRegister = new Command(() =>
            {
                Application.Current.MainPage = new View.Registration();
            });
        }

        public ICommand GoToRegister { get; private set; }
    }
}
