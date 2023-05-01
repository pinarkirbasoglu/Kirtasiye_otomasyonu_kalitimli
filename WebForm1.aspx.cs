using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;

namespace Kirtasiye_otomasyonu_Kalitimli
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ursay = Convert.ToInt32(Interaction.InputBox("kaç adet ürün gireceksiniz:"));
            Urun[] urunler =new Urun[ursay];
            int sayac = 0;
            for(int i=0; i<urunler.Length; i++)
            {
                bool kontrol = false;
                int BarNo = Convert.ToInt32(Interaction.InputBox("barkod giriniz:"));
                foreach(Urun gel in  urunler)
                {
                    if(gel != null)
                    {
                        if (gel.Barkod == BarNo)
                        {
                            kontrol = true;
                            Interaction.MsgBox("barkod numarası önceden girilmiştir", MsgBoxStyle.YesNo);
                            break;
                        }
                    }
                }//foreach
                if (kontrol == true)
                {
                    i--;
                    continue;
                }
                byte secim = Convert.ToByte(Interaction.InputBox("1-Kitap, 2-Sarf malzeme"));
                switch(secim)
                {
                    case 1:
                        Kitap kit = new Kitap()
                        {
                            Barkod = BarNo,
                            Ad = Interaction.InputBox("kitap adı girin:"),
                            Yazar = Interaction.InputBox("kitap yazarını girin:"),
                            Sayfa = Convert.ToInt16(Interaction.InputBox("sayfa sayısı girin")),
                            Fiyat = Convert.ToInt32(Interaction.InputBox("kitap fiyatı girin:")),
                            Ted = ted_bil()
                        };
                        urunler[i]=kit;
                        break;
                    case 2:
                        SMalzeme sm = new SMalzeme()
                        {
                            Barkod = BarNo,
                            Ad = Interaction.InputBox("ürün adı girin:"),
                            Tur = Interaction.InputBox("ürün türünü girin:"),
                            Fiyat = Convert.ToInt32(Interaction.InputBox("ürün fiyatını girin:")),
                            Ted = ted_bil()
                        };
                        urunler[i] = sm;
                        break;
                }//switch
                sayac++;
                int cvp = Convert.ToInt32(Interaction.MsgBox("devam edeck misiniz", MsgBoxStyle.YesNo));
                if (cvp == 7) break;
            }//for
            Array.Resize(ref urunler, sayac);
            byte islem = Convert.ToByte(Interaction.InputBox("1-ürün al, 2-ürünleri listele"));
            switch (islem)
            {
                case 1:
                    int bar = Convert.ToInt32(Interaction.InputBox("almak istediğinz ürünü barkodunu girin:"));
                    int adet = Convert.ToInt32(Interaction.InputBox("kaç adet ürün alacaksınız"));
                    foreach(Urun urunum in urunler)
                    {
                        if (urunum.Barkod == bar)
                        {
                            if (urunum is Kitap) Response.Write(((Kitap)urunum).KitapBil() + " " + "toplam tutar:" + ((((Kitap)urunum).Fiyat) * adet));
                            if (urunum is SMalzeme) Response.Write(((SMalzeme)urunum).SBil() + " " + "toplam tutar:" + ((((SMalzeme)urunum).Fiyat) * adet));
                        }
                        
                        
                    }
                    break;
                case 2:
                    
                    Response.Write("<table border =1>");
                    Response.Write("<tr><td>ÜRÜN TÜRÜ</td><td>ad</td><td>barkod</td><td>fiyat</td><td>tedarikçi bilgileri</td><td>tür</td><td>yazar adı</td><td>sayfa sayısı</td></tr>");
                    foreach(Urun tbl in urunler)
                    {
                        if (tbl is Kitap)
                            Response.Write("<tr><td>KİTAP</td><td>" + (((Kitap)tbl).Ad) + "</td><td>" + (((Kitap)tbl).Barkod) + "</td><td>" +
                                (((Kitap)tbl).Fiyat) + "</td><td>" + (((Kitap)tbl).Ted.TedBil()) + "</td><td></td><td>" +
                                (((Kitap)tbl).Yazar) + "</td><td>" + (((Kitap)tbl).Sayfa) + "</td></tr>");
                        if (tbl is SMalzeme)
                            Response.Write("<tr><td>SARF MALZEME</td><td>" + (((SMalzeme)tbl).Ad) + "</td><td>" + (((SMalzeme)tbl).Barkod) + "</td><td>" +
                             (((SMalzeme)tbl).Fiyat) + "</td><td>" + (((SMalzeme)tbl).Ted.TedBil()) + "</td><td>" + (((SMalzeme)tbl).Tur) + "</td><td></td><td></td></tr>");
                      
                    }
                    break;
            }//switch
        }//buton click
        private Tedarik ted_bil()
        {
            Tedarik tdr = new Tedarik()
            {
                Ad=Interaction.InputBox("tedarikçi  adi giriniz:"),
                Tel=Convert.ToInt32(Interaction.InputBox(" tedarikçi telefon girin:"))
            };
            return tdr;
        }
    }
}