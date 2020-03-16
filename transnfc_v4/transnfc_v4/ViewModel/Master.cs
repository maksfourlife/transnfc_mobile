using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace transnfc_v4.ViewModel
{
    class Master : INotifyPropertyChanged
    {
        public Master(MasterDetailPage master)
        {
            Action<Page> set_page = page =>
            {
                master.Detail = new NavigationPage(page)
                {
                    BarBackgroundColor = (Color)Application.Current.Resources["blue1"],
                };
                master.IsPresented = false;
            };

            NewPageSelected = new Command<string>(page_name =>
            {
                switch (page_name)
                {
                    case "Main":
                        set_page(new View.Main());
                        return;
                    case "Wallet":
                        set_page(new View.Wallet());
                        return;
                    case "Settings":
                        set_page(new View.Settings());
                        return;
                    case "Feedback":
                        set_page(new View.Feedback());
                        return;
                    case "Exit":
                        string[] keys = { "id", "login", "email", "pwd", "first", "last" };
                        foreach (string key in keys)
                            Application.Current.Properties.Remove(key);
                        Application.Current.SavePropertiesAsync();
                        Application.Current.MainPage = new View.Login();
                        return;
                }
            });

            set_page(new View.Main());
        }

        public Command<string> NewPageSelected { private set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
