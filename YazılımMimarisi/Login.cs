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
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.Admins;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi
{
    public partial class Login : Form
    {

        private  IAdminService _adminService;
        public Login()
        {
            InitializeComponent();
        }
        public Login(IAdminService _adminService)
        { 
          
            this._adminService = _adminService;
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            HttpClient _client = new HttpClient();
            _adminService = new AdminService(_client);
            BaseResponse<Admin> response = await _adminService.GetAdmin("60b65e6de22dcb482f0ff874");
            Admin admin = response.Content[0];
            MessageBox.Show(admin.Password);
        }
    }
}
