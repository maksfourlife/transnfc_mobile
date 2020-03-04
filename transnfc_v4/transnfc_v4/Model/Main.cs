using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Model
{
    class Main
    {
        public List<Data.Payment> PaymentList { get; set; }
        public string Wallet;

        public Main()
        {
            Wallet = Data.Converter.ConvertMoney(4350);
            PaymentList = new List<Data.Payment>
            {
                new Data.Payment(DateTime.Now, "1A", 6000),
                new Data.Payment(DateTime.Now, "1A", 6000),
                new Data.Payment(DateTime.Now, "1A", 6000),
                new Data.Payment(DateTime.Now, "1A", 6000),
            };
        }
    }
}
