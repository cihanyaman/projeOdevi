using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsaSatisi
{
    class Talep
    {
        private Kullanici alici;
        private string urun;
        private int miktar;

        public Talep(Kullanici alici, string urun, int miktar)
        {
            Alici = alici;
            Urun = urun;
            Miktar = miktar;
        }
        public void AlimiGerceklestir(Nesne urun)
        {
            Islem islem;
            double baslangicBakiye = alici.Bakiye;
            int gecicimiktar = miktar;
            double toplamTutar = urun.Fiyat * miktar;
            if (urun.Miktar >= miktar && alici.Bakiye >= toplamTutar)
            {
                urun.Miktar -= miktar;
                miktar = 0;
                alici.Bakiye -= toplamTutar;
                alici.NesneEkle(urun);
                urun.Sahibi.Bakiye += toplamTutar;
            }
            else if (urun.Miktar >= miktar && alici.Bakiye <= toplamTutar)
            {
                int alinabilecekMiktar = (int)(alici.Bakiye / urun.Fiyat);
                toplamTutar = alinabilecekMiktar * urun.Fiyat;
                urun.Miktar -= alinabilecekMiktar;
                miktar -= alinabilecekMiktar;
                alici.Bakiye -= toplamTutar;
                urun.Sahibi.Bakiye += toplamTutar;
                Nesne yeniUrun = new Nesne(urun.Ad, alinabilecekMiktar, urun.Fiyat, alici);
                alici.NesneEkle(yeniUrun);
            }
            else
            {
                int alinabilecekMiktar = urun.Miktar;
                toplamTutar = alinabilecekMiktar * urun.Fiyat;
                alici.Bakiye -= toplamTutar;
                urun.Sahibi.Bakiye += toplamTutar;
                miktar -= urun.Miktar;
                Nesne yeniUrun = new Nesne(urun.Ad, alinabilecekMiktar, urun.Fiyat, alici);
                alici.NesneEkle(yeniUrun);
            }
            if (baslangicBakiye != alici.Bakiye)
            {
                islem = new Islem(alici.Ad + " " + gecicimiktar + " kilo " + urun.Ad + " almak ister ise " + urun.Fiyat + " tl'den alım işlemi gerçekleşti",
                alici.Ad + " " + urun.Sahibi.Ad + "'in hesabına " + toplamTutar + " TL gönderdi.", alici.Ad + " " + alici.Bakiye + " tl parası kaldı",
                urun.Fiyat + " tl");
                Veriler.Islemler.Add(islem);
            }
        }
        public bool Tamamlandimi()
        {
            return miktar == 0;
        }
        public Kullanici Alici { get => alici; set => alici = value; }
        public string Urun { get => urun; set => urun = value; }
        public int Miktar { get => miktar; set => miktar = value; }
    }
}
