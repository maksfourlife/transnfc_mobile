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
    class Registration : INotifyPropertyChanged
    {
        private Model.Registration _model;

        public Registration()
        {
            _model = new Model.Registration();

            GoToLogin = new Command(() =>
            {
                Application.Current.MainPage = new View.Login();
            });

            Register = new Command(async () =>
            {
                Func<string, Task> mention_about_error = async (string message) => await Application.Current.MainPage.DisplayAlert("Ошибка!", message, "Ок");

                try
                {
                    Data.User data = await _model.Register(Application.Current.Resources["url"] as string);
                    if (data != null)
                    {
                        data.Bind(Application.Current.Properties);
                        await Application.Current.SavePropertiesAsync();
                        Application.Current.MainPage = new View.Master();
                    }
                }
                catch (Exception e)
                {
                    if (e is Exceptions.PasswordsMismatch)
                        await mention_about_error("Пароли не совпадают");
                    else if (e is Exceptions.EmptyField)
                        await mention_about_error("Одно или несколько полей пусты");
                    else if (e is Exceptions.EmailAlreadyTaken)
                        await mention_about_error("Пользвотель с данной почтой уже зарегестирован");
                    else if (e is Exceptions.NotEmail)
                        await mention_about_error("Пожалуйста, введите корректный email");
                    else
                        await mention_about_error($"Неизвестная ошибка - {e.Message}");
                }
            });
        }

        public ICommand GoToLogin { get; private set; }
        public ICommand Register { get; private set; }

        public string LastName
        {
            get { return _model.LastName; }
            set
            {
                _model.LastName = value;
                OnPropertyChanged();
            }
        }


        public string FirstName
        {
            get { return _model.FirstName; }
            set
            {
                _model.FirstName = value;
                OnPropertyChanged();
            }
        }


        public string Email
        {
            get { return _model.Email; }
            set
            {
                _model.Email = value;
                OnPropertyChanged();
            }
        }


        public string Password
        {
            get { return _model.Password; }
            set
            {
                _model.Password = value;
                OnPropertyChanged();
            }
        }


        public string PasswordCheck
        {
            get { return _model.PasswordCheck; }
            set
            {
                _model.PasswordCheck = value;
                OnPropertyChanged();
            }
        }

        public string Login
        {
            get { return _model.Login; }
            set
            {
                _model.Login = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
