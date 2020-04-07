using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace transnfc_v4.ViewModel
{
    class Main : INotifyPropertyChanged
    {
        private Model.Main Data;
        private ICommand Pay;

        public Main()
        {
            int user_id = (int)Application.Current.Properties["id"];
            Data = new Model.Main();
            Task.Run(async () =>
            {
                await Data.LoadPayments(user_id);
                OnPropertyChanged("PaymentList");
                OnPropertyChanged("NoRecent");
            });
            Task.Run(async () =>
            {
                await Data.LoadWallet(user_id);
                OnPropertyChanged("Wallet");
            });
            Pay = new Command(async () =>
            {
                OnPropertyChanged("")
            }, () => DependencyService.Get<ITagScanner>().NfcAvaible);
        }

        public bool NoRecent
        {
            get { return Data.NoRecent; }
            set
            {
                Data.NoRecent = value;
                OnPropertyChanged();
            }
        }

        public bool Processing
        {
            get { return Data.Processing; }
            set
            {
                Data.Processing = value;
                OnPropertyChanged();
            }
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
