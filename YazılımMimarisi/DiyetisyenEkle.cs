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
    public partial class DiyetisyenEkle : Form
    {
        public DiyetisyenEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                //AdminPaneli sayfasına git
                AdminPaneli frm = new AdminPaneli();
                frm.Show();
                this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Lütfen boş kutu bırakmayınız...");
            }
        }
    }
}
