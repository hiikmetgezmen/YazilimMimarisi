using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Common.Enums;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.Dieticians;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi
{
    public partial class KullaniciEkrani : Form
    {
        IDieticianService _dieticianService;

        public KullaniciEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HastaEkle sayfasına git
            HastaEkle frm = new HastaEkle();
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

        private async void KullaniciEkrani_Load(object sender, EventArgs e)
        {
            HttpClient _client = new HttpClient();
            _dieticianService = new DieticianService(_client);
            BaseResponse<Dietician> response = await _dieticianService.GetDietician(Program.DieticianId);
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                label2.Text = response.Content[0].Name;
            }
            else
            {
                MessageBox.Show("Böyle bir kullanıcı bulunamadı veya şifre hatalı.");
            }
           
        }
    }
}
