using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Model
{
    class Main
    {
        public List<Data.Payment> PaymentList { get; set; }
        public string Wallet;
        public bool CoverShown;

        public Main()
        {
            CoverShown = false;
            Wallet = "43";
            PaymentList = new List<Data.Payment>
            {
                new Data.Payment(DateTime.Now, "1A", 60),
                new Data.Payment(DateTime.Now, "1A", 60),
                new Data.Payment(DateTime.Now, "1A", 60),
                new Data.Payment(DateTime.Now, "1A", 60),
            };
        }
    }
}
