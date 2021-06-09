using System;
using System.Net.Http;
using System.Windows.Forms;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Common.Enums;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.Admins;
using YazılımMimarisi.Services.Dieticians;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi
{
    public partial class Login : Form
    {
        private  IDieticianService _dieticianService;
        public Login()
        {
            InitializeComponent();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            if (txtbox_username.Text == "" || txtbox_password.Text == "")
            {
                MessageBox.Show("Lütfen boş kutu bırakmayınız...");
            }
            else
            {
                if (txtbox_username.Text == "admin" && txtbox_password.Text =="admin")
                {
                    //AdminPaneli sayfasına git
                    AdminPaneli frm = new AdminPaneli();
                    frm.ShowDialog();
                    this.Visible = false;
                }
                else
                {
                    HttpClient _client = new HttpClient();
                    _dieticianService = new DieticianService(_client);
                    Dietician dietician = new Dietician() {Username = txtbox_username.Text,Password = txtbox_password.Text };
                    BaseResponse<Dietician> response = await _dieticianService.Login(dietician);
                    if (response.Status.Value== ResponseStatus.Success.Value)
                    {
                        Program.DieticianId = response.Content[0].Id;
                        //KullaniciEkrani sayfasına git
                        KullaniciEkrani frm = new KullaniciEkrani();
                        frm.ShowDialog();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Böyle bir kullanıcı bulunamadı veya şifre hatalı.");
                    }
                }
            }
        }
    }
}
