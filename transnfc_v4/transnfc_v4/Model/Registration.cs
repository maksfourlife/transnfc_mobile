using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace transnfc_v4.Model
{
    class Registration
    {
        public string Email = "";
        public string Login = "";
        public string Password = "";
        public string PasswordCheck = "";
        public string FirstName = "";
        public string LastName = "";

        public async Task<Data.User> Register(string url)
        {
            if (Email == "" || Login == "" || Password == "" || PasswordCheck == "" || FirstName == "" || LastName == "")
                throw new Exceptions.EmptyField();
            if (Password != PasswordCheck)
                throw new Exceptions.PasswordsMismatch();
            if (!Regex.IsMatch(Email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                throw new Exceptions.NotEmail();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync($"{url}/api/register", new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "email", Email },
                    { "login", Login },
                    { "pwd", Password },
                    { "first", FirstName },
                    { "last", LastName }
                }));
                if (response.IsSuccessStatusCode)
                {
                    dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    if ((bool)data.success)
                    {
                        return new Data.User(Email, Login, Password, FirstName, LastName, (int)data.id);
                    }
                    else
                    {
                        switch ((string)data.message)
                        {
                            case "Login already taken":
                                throw new Exceptions.LoginAlreadyTaken();
                            case "Email already taken":
                                throw new Exceptions.EmailAlreadyTaken();
                        }
                    }
                }
            }
            return null;
        }
    }
}
