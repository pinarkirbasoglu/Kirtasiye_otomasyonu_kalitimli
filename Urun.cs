using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kirtasiye_otomasyonu_Kalitimli
{
    public class Urun
    {
        private int fiyat;
        private string ad;
        private int barkod;
        private Tedarik ted;

        public int Fiyat { get => fiyat; set => fiyat = value; }
        public string Ad { get => ad; set => ad = value; }
        public int Barkod { get => barkod; set => barkod = value; }
        public Tedarik Ted { get => ted; set => ted = value; }

        protected string UrunBil()
        {
            return "ad:" + Ad + " " + "barkod:" + Barkod + " " + "ürün fiyatı:"
                + Fiyat + " " + "tedarikçi bilgileri:" + ted.TedBil();
        }
    }
}