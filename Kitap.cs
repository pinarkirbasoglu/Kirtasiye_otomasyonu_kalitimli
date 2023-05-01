using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kirtasiye_otomasyonu_Kalitimli
{
    public class Kitap:Urun
    {
        private string yazar;
        private short sayfa;

        public string Yazar { get => yazar; set => yazar = value; }
        public short Sayfa { get => sayfa; set => sayfa = value; }

        public string KitapBil()
        {
            return UrunBil() + " " + "kitap yazarı:" + Yazar + " " + "sayfa saysıs:"
                + Sayfa;
        }
    }
}