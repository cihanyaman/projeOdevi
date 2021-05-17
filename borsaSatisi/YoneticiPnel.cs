using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsaSatisi
{
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Islemler().ShowDialog();
        }
        void PanelGuncelle()
        {
            foreach (Kullanici kullanici in Veriler.uyeler)
            {
                listBox1.Items.Add(kullanici.KullaniciAdi + " - " + kullanici.Ad + " " + kullanici.Soyad + " Bakiye: " + kullanici.Bakiye);
            }
        }
        void TalepleriGuncelle()
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string kadi = listBox1.SelectedItem.ToString().Split('-')[0].Trim();
                Kullanici secilen = Veriler.kullaniciBul(kadi);
                listBox2.Items.Clear();
                lbltalep.Text = secilen.BakiyeOnay.ToString() + " TL";
                foreach (Nesne urun in secilen.Esyalar)
                {
                    if (urun.Onay == false)
                    {
                        listBox2.Items.Add("Ad :" + urun.Ad + " Miktar: " + urun.Miktar + " Fiyat: " + urun.Fiyat + " TL");
                    }
                }
            }
        }
        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            PanelGuncelle();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TalepleriGuncelle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string kadi = listBox1.SelectedItem.ToString().Split('-')[0].Trim();
                Kullanici secilen = Veriler.kullaniciBul(kadi);
                foreach (Nesne urun in secilen.Esyalar)
                {
                    if (urun.Onay == false)
                    {
                        urun.Onay = true;
                    }
                }
            }
            TalepleriGuncelle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string kadi = listBox1.SelectedItem.ToString().Split('-')[0].Trim();
                Kullanici secilen = Veriler.kullaniciBul(kadi);
                secilen.Bakiye += secilen.BakiyeOnay;
                secilen.BakiyeOnay = 0;
            }
            TalepleriGuncelle();
        }
    }
}
