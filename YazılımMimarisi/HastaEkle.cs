using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazılımMimarisi
{
    public partial class HastaEkle : Form
    {
        public HastaEkle()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                //KullaniciEkrani sayfasına git
                KullaniciEkrani frm = new KullaniciEkrani();
                frm.Show();
                this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_tcno.Text == "" || txt_name.Text == "" || txt_surname.Text == "" || textBox4.Text == "" || textBox5.Text == "" || txt_email.Text == "" || comboBox1.Text == "" || cmbox_disease.Text == "")
            {
                MessageBox.Show("Lütfen boş kutu bırakmayınız...");
            }
          
        }
    }
}
