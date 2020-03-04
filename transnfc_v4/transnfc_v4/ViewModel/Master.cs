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
        public Master(Action<string> new_page_selected)
        {
            NewPageSelected = new Command<string>(new_page_selected);
        }

        public Command<string> NewPageSelected { private set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
