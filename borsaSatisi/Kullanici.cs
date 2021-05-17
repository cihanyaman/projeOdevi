using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsaSatisi
{
    public class Kullanici
    {
        private string adres;
        private string ad;
        private string soyad;
        private string kullaniciAdi;
        private string sifre;
        private string tC;
        private string telefon;
        private string email;
        private List<Nesne> esyalar;
        private double bakiye;
        private double bakiyeOnay;
        public Kullanici(string kullaniciAdi, string sifre, string tC, string ad, string soyad, string telefon, string email, string adres)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            TC = tC;
            Ad = ad;
            Soyad = soyad;
            Telefon = telefon;
            Email = email;
            Adres = adres;
            Bakiye = 0;
            BakiyeOnay = 0;
            Esyalar = new List<Nesne>();
        }
        public void NesneEkle(Nesne nesne)
        {
            if (esyalar.Contains(nesne) == false)
            {
                esyalar.Add(nesne);
            }
        }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string KullaniciAdi { get => kullaniciAdi; set => kullaniciAdi = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string TC { get => tC; set => tC = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }
        public string Adres { get => adres; set => adres = value; }
        public double Bakiye { get => bakiye; set => bakiye = value; }
        internal List<Nesne> Esyalar { get => esyalar; set => esyalar = value; }
        public double BakiyeOnay { get => bakiyeOnay; set => bakiyeOnay = value; }
    }
}
