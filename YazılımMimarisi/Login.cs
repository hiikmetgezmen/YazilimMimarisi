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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Lütfen boş kutu bırakmayınız...");
            }
            else
            {
                if (textBox1.Text == "a")
                {
                    //AdminPaneli sayfasına git
                    AdminPaneli frm = new AdminPaneli();
                    frm.ShowDialog();
                    this.Visible = false;
                }
                else
                {
                    //KullaniciEkrani sayfasına git
                    KullaniciEkrani frm = new KullaniciEkrani();
                    frm.ShowDialog();
                    this.Visible = false;
                }
            }
        }
    }
}
