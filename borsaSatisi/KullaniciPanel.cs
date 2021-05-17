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
    public partial class KullaniciPanel : Form
    {
        Kullanici kullanici;
        public KullaniciPanel(Kullanici kullanici)
        {
            this.kullanici = kullanici;
            InitializeComponent();
        }

        private void KullaniciPanel_Load(object sender, EventArgs e)
        {
            Text = "Hoşgeldiniz " + kullanici.Ad + " " + kullanici.Soyad + DateTime.Now.ToShortDateString();
            PanelGuncelle();
        }

        void PanelGuncelle()
        {
            listBox1.Items.Clear();
            foreach (Nesne nesne in kullanici.Esyalar)
            {
                listBox1.Items.Add("Ad :" + nesne.Ad + " Fiyat: " + nesne.Fiyat + " Miktar: " + nesne.Miktar);
            }
            listBox2.Items.Clear();
            List<Talep> talepler = Veriler.KullaniciTalepleri(kullanici);
            foreach (Talep talep in talepler)
            {
                listBox2.Items.Add("Ad: " + talep.Urun + " Miktar: " + talep.Miktar);
            }
            bakiyelbl.Text = kullanici.Bakiye.ToString() + " TL";
            bakiyeonaylbl.Text = kullanici.BakiyeOnay.ToString() + " TL";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbad.SelectedIndex >= 0)
            {
                Nesne yeni = new Nesne(cbad.Text, int.Parse(tbmiktar.Value.ToString()), double.Parse(tbbirimfiyat.Value.ToString()), kullanici);
                kullanici.NesneEkle(yeni);
                PanelGuncelle();
                MessageBox.Show("Eşya onaya gönderildi.");
            }
            else MessageBox.Show("Seçim yapınız.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                kullanici.BakiyeOnay += double.Parse(textBox1.Text);
                PanelGuncelle();
                MessageBox.Show("Bakiye onaya gönderildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı değer girildi.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbad.SelectedIndex >= 0)
            {
                Talep talep = new Talep(kullanici, cbad.Text, int.Parse(tbmiktar.Value.ToString()));
                Veriler.AlisTalepleri.Add(talep);
                Veriler.TalepKontrol();
                PanelGuncelle();
                MessageBox.Show("Alış talebiniz oluşturuldu.");
            }
        }

        private void cbad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
