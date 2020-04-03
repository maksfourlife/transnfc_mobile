using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Data
{
    class User
    {
        public string Email;
        public string Login;
        public string Password;
        public string FirstName;
        public string LastName;
        public int Id;

        public User(string email, string login, string password, string first_name, string last_name, int id)
        {
            Email = email;
            Login = login;
            Password = password;
            FirstName = first_name;
            LastName = last_name;
            Id = id;
        }

        public void Bind(IDictionary<string, object> properties)
        {
            properties["id"] = Id;
            properties["email"] = Email;
            properties["pwd"] = Password;
            properties["first"] = FirstName;
            properties["last"] = LastName;
            properties["login"] = Login;
        }
    }
}
