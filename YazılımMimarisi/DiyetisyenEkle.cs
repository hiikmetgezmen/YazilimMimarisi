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
    public partial class DiyetisyenEkle : Form
    {

        IDieticianService _dieticianService;
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

        private async void button1_Click(object sender, EventArgs e)
        {

            if (txt_tcno.Text == "" || txt_name.Text == "" || txt_surname.Text == "" || txt_username.Text == "" || txt_password.Text == "" || txt_email.Text == "" || txt_address.Text == "")
            {
                MessageBox.Show("Lütfen boş kutu bırakmayınız...");
            }
            else
            {
                HttpClient _client = new HttpClient();
                _dieticianService = new DieticianService(_client);
                Contact contact = new Contact() {
                    Address = txt_address.Text,
                    Email = txt_email.Text
                };
                Dietician dietician = new Dietician()
                {
                    IDNumber = txt_tcno.Text,
                    Name = txt_name.Text,
                    LastName = txt_surname.Text,
                    Username = txt_username.Text,
                    Password = txt_password.Text,
                    Contact = contact
                };
                BaseResponse<Dietician> response = await _dieticianService.CreateDietician(dietician);
                if (response.Status.Value == ResponseStatus.Success.Value)
                {
                    //KullaniciEkrani sayfasına git
                    MessageBox.Show("Başarılı bir şekilde eklendi");
                }
                else
                {
                    MessageBox.Show("diyetisyen oluşturulamadı");
                }
            }
        }
    }
}
