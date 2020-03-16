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
    class Login : INotifyPropertyChanged
    {
        private Model.Login _model;

        public Login()
        {
            _model = new Model.Login();

            GoToRegister = new Command(() =>
            {
                Application.Current.MainPage = new View.Registration();
            });

            LogIn = new Command(async () =>
            {
                Func<string, Task> mention_about_error = async (string message) => await Application.Current.MainPage.DisplayAlert("Ошибка!", message, "OK");

                try
                {
                    Data.User data = await _model.LogIn(Application.Current.Resources["url"] as string);
                    if (data != null)
                    {
                        Application.Current.Properties["id"] = data.Id;
                        Application.Current.Properties["login"] = data.Login;
                        Application.Current.Properties["pwd"] = data.Password;
                        Application.Current.Properties["first"] = data.FirstName;
                        Application.Current.Properties["last"] = data.LastName;
                        Application.Current.Properties["email"] = data.Email;
                        await Application.Current.SavePropertiesAsync();
                        Application.Current.MainPage = new View.Master();
                    }
                }
                catch (Exception e)
                {
                    if (e is Exceptions.EmptyField)
                        await mention_about_error("Одно или несколько полей пусты");
                    else if (e is Exceptions.NotEmail)
                        await mention_about_error("Пожалуйста, введите корректную почту");
                    else if (e is Exceptions.LoginEmailNotFound)
                        await mention_about_error("Пользователь с данным логином или почтой не найден");
                    else if (e is Exceptions.InccorrectPassword)
                        await mention_about_error("Неверный пароль");
                    else
                        await mention_about_error($"Неизвестная ошибка - {e}\n\n {e.Message}");
                }
            });
        }

        public string LoginOrEmail
        {
            get { return _model.LoginOrEmail; }
            set
            {
                _model.LoginOrEmail = value;
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

        public ICommand GoToRegister { get; private set; }
        public ICommand LogIn { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string property_name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
