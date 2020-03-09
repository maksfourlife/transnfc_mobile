using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Data
{
    class Payment
    {
        public string Time { get { return $"{_time.Day} {Convert.ConvertMonth(_time.Month)} в {_time.Hour}:{Convert.ConvertMinute(_time.Minute)}"; } }
        private DateTime _time;

        public string Route { get { return $"Маршрут {_route}"; } }
        private string _route;

        public string Price { get { return $"-{_price}{(char)0x20bd}"; } }
        private int _price;

        public Payment(DateTime time, string route, int price)
        {
            _time = time;
            _route = route;
            _price = price;
        }
    }
}
