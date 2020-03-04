﻿using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Data
{
    struct Converter
    {
        public static string ConvertMoney(int a)
        {
            string s = a.ToString();
            return s.Insert(s.Length - 2, ".");
        }

        public static string ConvertMonth(int n)
        {
            switch (n)
            {
                case 1:
                    return "Января";
                case 2:
                    return "Февраля";
                case 3:
                    return "Марта";
                case 4:
                    return "Апреля";
                case 5:
                    return "Май";
                case 6:
                    return "Июня";
                case 7:
                    return "Июля";
                case 8:
                    return "Августа";
                case 9:
                    return "Сентября";
                case 10:
                    return "Октября";
                case 11:
                    return "Ноября";
                case 12:
                    return "Декабря";
            }
            return default;
        }

        public static string ConvertMinute(int m)
        {
            string s = m.ToString();
            if (s.Length == 2)
                return s;
            return '0' + s;
        }
    }
}
