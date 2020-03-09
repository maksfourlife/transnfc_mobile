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

        public async Task<Data.UserData> Register(string url)
        {
            if (Email == "" || Login == "" || Password == "" || PasswordCheck == "" || FirstName == "" || LastName == "")
                throw new Data.EmptyFieldException();
            if (Password != PasswordCheck)
                throw new Data.PasswordsDontMatchException();
            if (!Regex.IsMatch(Email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                throw new Data.NotEmailException();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync($"{url}/api/login", new FormUrlEncodedContent(new Dictionary<string, string>
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
                    if (data.success)
                    {
                        return new Data.UserData(data.email, data.login, data.pwd, data.first, data.last, data.id);
                    }
                    else
                    {
                        switch (data.message)
                        {
                            case "lastname taken":
                                throw new Data.AlreadyTakenLastNameException();
                            case "firstname taken":
                                throw new Data.AlreadyTakenFirstNameException();
                            case "email taken":
                                throw new Data.AlreadyTakenEmailException();
                        }
                    }
                }
            }
            return null;
        }
    }
}
