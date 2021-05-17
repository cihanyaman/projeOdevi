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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanici yeniKayit = new Kullanici(tbkadi.Text, tbsifre.Text, tbtc.Text, tbad.Text, tbsoyad.Text, tbtelefon.Text, tbemail.Text, tbadres.Text);
            if (Veriler.KayitOl(yeniKayit))
            {
                MessageBox.Show("Kayıt başarılı.");
            }
            else
            {
                MessageBox.Show("Kayıt başarısız.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                new YoneticiPaneli().ShowDialog();
            }
            else
            {
                Kullanici giris = Veriler.GirisYap(textBox1.Text, textBox2.Text);
                if (giris != null)
                {
                    new KullaniciPanel(giris).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı/şifre hatalı.");
                }
            }
        }
    }
}
