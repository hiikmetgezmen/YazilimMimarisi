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
using YazılımMimarisi.Services.Patients;

namespace YazılımMimarisi
{
    public partial class KullaniciEkrani : Form
    {
        IDieticianService _dieticianService;
        IPatientService _patientService;
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

        private void KullaniciEkrani_Load(object sender, EventArgs e)
        {
            GetDieticianName();
            PatientsLoadDataGrid();
        }
        private async void GetDieticianName()
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

        private async void PatientsLoadDataGrid()
        {
            HttpClient _client = new HttpClient();
            _patientService = new PatientService(_client);
            BaseResponse<Patient> response = await _patientService.GetAllPatientByDietician(Program.DieticianId);
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                dataGridView1.DataSource = response.Content;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DietYönetmi sayfasına git
            DiyetYöntemiEkle frm = new DiyetYöntemiEkle();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Diet sayfasına git
            DiyetEkle frm = new DiyetEkle();
            frm.Show();
            this.Close();
        }
    }
}
