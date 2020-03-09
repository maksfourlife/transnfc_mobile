using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace transnfc_v4.Model
{
    class Login
    {
        public string LoginOrEmail = "";
        public string Password = "";

        public async Task<Data.User> LogIn(string url)
        {
            if (LoginOrEmail == "" || Password == "")
                throw new Exceptions.EmptyField();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync($"{url}/api/login", new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "login_or_email", LoginOrEmail },
                    { "pwd", Password }
                }));
                if (response.IsSuccessStatusCode)
                {
                    dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    if (data.success)
                    {
                        return new Data.User(data.email, data.login, data.pwd, data.first, data.last, data.id);
                    }
                    switch (data.message)
                    {
                        case "login not found":
                            throw new Exceptions.LoginNotFound();
                        case "email not found":
                            throw new Exceptions.EmailNotFound();
                        case "incorrect pwd":
                            throw new Exceptions.InccorrectPassword();
                    }
                }
            }
            return null;
        }
    }
}
