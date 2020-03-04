using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace transnfc_v4.ViewModel
{
    class Main : INotifyPropertyChanged
    {
        private Model.Main Data;

        public Main()
        {
            Data = new Model.Main();
        }

        public List<Data.Payment> PaymentList
        {
            get { return Data.PaymentList; }
            set
            {
                Data.PaymentList = value;
                OnPropertyChanged();
            }
        }

        public string Wallet
        {
            get { return Data.Wallet + (char)0x20bd; }
            set
            {
                Data.Wallet = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string property_name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
