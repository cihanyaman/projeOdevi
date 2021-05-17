using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsaSatisi
{
    class Islem
    {
        private DateTime tarihSaat;
        private string detay;
        private string tutar;
        private string alicikalan;
        private string birimfiyat;

        public Islem(string detay, string tutar, string alicikalan, string birimfiyat)
        {
            TarihSaat = DateTime.Now;
            Detay = detay;
            Tutar = tutar;
            Alicikalan = alicikalan;
            Birimfiyat = birimfiyat;
        }

        public DateTime TarihSaat { get => tarihSaat; set => tarihSaat = value; }
        public string Detay { get => detay; set => detay = value; }
        public string Tutar { get => tutar; set => tutar = value; }
        public string Alicikalan { get => alicikalan; set => alicikalan = value; }
        public string Birimfiyat { get => birimfiyat; set => birimfiyat = value; }
    }
}
