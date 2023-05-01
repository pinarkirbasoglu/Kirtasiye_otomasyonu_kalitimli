using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kirtasiye_otomasyonu_Kalitimli
{
    public class SMalzeme:Urun
    {
        private string tur;

        public string Tur { get => tur; set => tur = value; }

        public string SBil()
        {
            return UrunBil() + " " + "malzeme türü:" + Tur;
        }
    }
}