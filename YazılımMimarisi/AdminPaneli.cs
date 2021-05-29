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
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DiyetisyenEkle sayfasına git
            DiyetisyenEkle frm = new DiyetisyenEkle();
            frm.Show();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Login sayfasına git
            Login frm = new Login();
             frm.Show();
             this.Close();
            }
    }
}
