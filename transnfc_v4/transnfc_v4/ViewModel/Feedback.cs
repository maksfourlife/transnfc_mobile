using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace transnfc_v4.ViewModel
{
    class Feedback : INotifyPropertyChanged
    {
        public Feedback(Page binder)
        {
            OptionSelected = new Command<string>(async (string option) =>
            {
                switch (option)
                {
                    case "UserAgreement":
                        await binder.Navigation.PushAsync(new View.UserAgreement());
                        return;
                    case "License":
                        await binder.Navigation.PushAsync(new View.License());
                        return;
                    case "ReportAPropblem":
                        return;
                    case "Contacts":
                        return;
                }
            });
        }

        public Command<string> OptionSelected { private set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
