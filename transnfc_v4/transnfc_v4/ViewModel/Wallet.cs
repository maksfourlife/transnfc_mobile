using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace transnfc_v4.ViewModel
{
    class Wallet : INotifyPropertyChanged
    {
        private Model.Wallet _model;

        public Wallet()
        {

        }

        public string SumField
        {
            get { return  }
        }

        public ICommand SumFieldChanged { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }


    }
}
