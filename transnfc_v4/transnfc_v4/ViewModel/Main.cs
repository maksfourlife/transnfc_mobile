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
        public ICommand Pay { get; }

        public Main()
        {
            int user_id = (int)Application.Current.Properties["id"];
            Data = new Model.Main();
            Update(user_id);
            Pay = new Command(() =>
            {
                Processing = true;
                Data.Pay(user_id, async (bool success) =>
                {
                    if (success)
                    {
                        Update(user_id);
                        await Application.Current.MainPage.DisplayAlert("Успешно!", "Оплата произведена", "Ок");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Ошибка!", "Не получилось произвести оплату", "Ок");
                    }
                    Processing = false;
                });
            }, () => DependencyService.Get<ITagScanner>().NfcAvaible);
        }

        private void Update(int user_id)
        {
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
                OnPropertyChanged("NotProcessing");
            }
        }

        public bool NotProcessing
        {
            get { return !Data.Processing; }
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
