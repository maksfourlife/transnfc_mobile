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
                    { "login_email", LoginOrEmail },
                    { "pwd", Password }
                }));
                if (response.IsSuccessStatusCode)
                {
                    dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    if ((bool)data.success)
                    {
                        return new Data.User((string)data.email, (string)data.login, (string)data.pwd, (string)data.first, (string)data.last, (int)data.id);
                    }
                    switch ((string)data.message)
                    {
                        case "No such login or email":
                            throw new Exceptions.LoginEmailNotFound();
                        case "Incorrect password":
                            throw new Exceptions.InccorrectPassword();
                    }
                }
            }
            return null;
        }
    }
}
