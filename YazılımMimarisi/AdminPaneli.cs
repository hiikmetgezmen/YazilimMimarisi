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
    public partial class AdminPaneli : Form
    {
        IDieticianService _dieticianService;
        public AdminPaneli()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
          //  DiyetisyenEkle sayfasına git
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

        private async void AdminPaneli_LoadAsync(object sender, EventArgs e)
        {
            HttpClient _client = new HttpClient();
            _dieticianService = new DieticianService(_client);
            BaseResponse<Dietician> response = await _dieticianService.GetAllDietician();
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                dataGridView1.DataSource = response.Content;
            }
            else
            {
                MessageBox.Show("API da bi hata oluştu");
            }
        }
    }
}
