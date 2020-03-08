using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace transnfc_v4.Model
{
    class Wallet
    {
        public string SumField;
        public List<Data.Purchase> PurchaseHistory;

        public Wallet()
        {
            SumField = "0";
            PurchaseHistory = new List<Data.Purchase>
            {
                new Data.Purchase(DateTime.Now, 60),
                new Data.Purchase(DateTime.Now, 35),
                new Data.Purchase(DateTime.Now, 60),
                new Data.Purchase(DateTime.Now, 35),
            };
        }

        public void SumFieldEntryChange(string new_value)
        {
            SumField = "";
            for (int i = 0; i < new_value.Length; i++)
                if (int.TryParse(new_value[i].ToString(), out _) && (new_value[i] != '0' || SumField.Length > 0))
                    SumField += new_value[i];
            if (SumField.Length == 0)
                SumField += "0";
        }
    }
}
