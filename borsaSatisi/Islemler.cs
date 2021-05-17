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
    public partial class Islemler : Form
    {
        public Islemler()
        {
            InitializeComponent();
        }

        private void Islemler_Load(object sender, EventArgs e)
        {
            foreach (Islem islem in Veriler.Islemler)
            {
                dataGridView1.Rows.Add(islem.TarihSaat, islem.Detay, islem.Tutar, islem.Alicikalan, islem.Birimfiyat);
            }
        }
    }
}
