using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsaSatisi
{
    class Admin : Kullanici
    {
        public Admin(string kullaniciAdi, string sifre, string tC, string ad, string soyad, string telefon, string email, string adres) : base(kullaniciAdi, sifre, tC, ad, soyad, telefon, email, adres)
        {

        }
        public static List<Nesne> OnaylanacakNesneler()
        {
            List<Nesne> liste = new List<Nesne>();
            foreach (Kullanici kullanici in Veriler.uyeler)
            {
                foreach (Nesne nesne in kullanici.Esyalar)
                {
                    if (!nesne.Onay)
                    {
                        liste.Add(nesne);
                    }
                }
            }
            return liste;
        }
    }
}
