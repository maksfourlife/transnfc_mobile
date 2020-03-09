using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Data
{
    class Purchase
    {
        public string Time { get { return $"{_time.Day} {Convert.ConvertMonth(_time.Month)} в {_time.Hour}:{Convert.ConvertMinute(_time.Minute)}"; } }
        private DateTime _time;

        public string Amount { get { return "+" + _amount.ToString() + (char)0x20bd; } }
        private int _amount;

        public Purchase(DateTime time, int amount)
        {
            _time = time;
            _amount = amount;
        }
    }
}
