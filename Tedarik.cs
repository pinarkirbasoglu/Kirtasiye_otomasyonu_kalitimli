using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kirtasiye_otomasyonu_Kalitimli
{
    public class Tedarik
    {
        private string ad;
        private int tel;

        public string Ad { get => ad; set => ad = value; }
        public int Tel { get => tel; set => tel = value; }

        public string TedBil()
        {
            return "tedarikçi adı:" + Ad + " " + "tedarikçi telefonu:" + Tel;
        }
    }
}