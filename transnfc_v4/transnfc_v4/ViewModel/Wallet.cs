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
            _model = new Model.Wallet();
        }

        public List<Data.Purchase> PurchaseHistory
        {
            get { return _model.PurchaseHistory; }
            set
            {
                _model.PurchaseHistory = value;
                OnPropertyChanged();
            }
        }

        public string SumFieldLabel
        {
            get { return _model.SumField + (char)0x20bd; }
        }

        public string SumFieldEntry
        {
            get { return _model.SumField; }
            set
            {
                _model.SumFieldEntryChange(value);
                OnPropertyChanged();
                OnPropertyChanged("SumFieldLabel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
