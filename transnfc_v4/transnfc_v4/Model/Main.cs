using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace transnfc_v4.Model
{
    class Main
    {
        public List<Data.Payment> PaymentList { get; set; } = new List<Data.Payment>();
        public string Wallet = "0";
        public bool Processing = false;
        public bool NoRecent = true;

        public async Task LoadPayments(int user_id, int amount = 4)
        {
            PaymentList.Clear();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = await client.PostAsync($"{Application.Current.Resources["url"]}/api/get_payments",
                    new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "id", user_id.ToString() },
                        { "amount", amount.ToString() }
                    }));
                if (res.IsSuccessStatusCode)
                {
                    Dictionary<string, dynamic> content = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(
                        await res.Content.ReadAsStringAsync());
                    if (!(bool)content["success"])
                        throw new Exception(content["message"] as string);
                    if (content["payments"].Count > 0)
                        NoRecent = false;
                    for (int i = 0; i < content["payments"].Count; i++)
                    {
                        dynamic payment = JsonConvert.DeserializeObject(content["message"][i]);
                        PaymentList.Add(new Data.Payment(Data.Convert.FromPython(payment.time), payment.route, payment.amount));
                    }
                }
            }
        }

        public async Task LoadWallet(int user_id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = await client.PostAsync($"{Application.Current.Resources["url"]}/api/get_wallet",
                    new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "id", user_id.ToString() }
                    }));
                if (res.IsSuccessStatusCode)
                {
                    Dictionary<string, dynamic> content = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(await res.Content.ReadAsStringAsync());
                    if (!(bool)content["success"])
                        throw new Exception(content["message"] as string);
                    long wallet = content["wallet"];
                    Wallet = wallet.ToString();
                }
            }
        }

        public void Pay(int user_id, Action<bool> finished)
        {
            bool success = false;
            DependencyService.Get<ITagScanner>().Scan(async (byte[] data) =>
            {
                if (data == null)
                    throw new Exception("Unable to read tag");
                else
                {
                    string _data = Data.Convert.HexFromBytes(data).ToLower();
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage res = await client.PostAsync($"{Application.Current.Resources["url"]}/api/pay",
                        new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            { "id", user_id.ToString() },
                            { "key", _data }
                        }));
                        if (res.IsSuccessStatusCode)
                        {
                            Dictionary<string, dynamic> content = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(await res.Content.ReadAsStringAsync());
                            if (!(bool)content["success"])
                                throw new Exception(content["message"] as string);
                            success = true;
                        }
                        else
                        {
                            throw new Exception($"Проблема с подключением - {await res.Content.ReadAsStringAsync()}");
                        }
                    }
                }
                finished(success);
            });
        }
    }
}
