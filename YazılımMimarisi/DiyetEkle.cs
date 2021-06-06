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
using YazılımMimarisi.Models.Entities.Diets;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.DietMethods;
using YazılımMimarisi.Services.Diets;
using YazılımMimarisi.Services.Interfaces;
using YazılımMimarisi.Services.Patients;

namespace YazılımMimarisi
{
    public partial class DiyetEkle : Form
    {
        private IDietService _dietService;
        private IPatientService _patientService;
        private IDietMethodService _dietMethodService;
        public DiyetEkle()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient _client = new HttpClient();
            _dietService = new DietService(_client);
            Diet diet = new Diet() {
                StartDate = dateTimePicker1.Value,
                EndDate = dateTimePicker2.Value,
                DietMethodId = ((KeyValuePair<string, string>)cmb_box_dietmethod.SelectedItem).Key
            };
            BaseResponse<Diet> response = await _dietService.CreateDiet(diet);
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                _client = new HttpClient();
                _patientService = new PatientService(_client);
                string patientId = ((KeyValuePair<string, string>)cmb_box_patients.SelectedItem).Key;
                BaseResponse<Patient> getPatientResponse = await _patientService.GetPatient(patientId);
                getPatientResponse.Content[0].DietId = response.Content[0].Id;
                BaseResponse<Patient> updatePatientResponse = await _patientService.UpdatePatient(getPatientResponse.Content[0]);
                if (updatePatientResponse.Status.Value != ResponseStatus.Success.Value)
                {
                    MessageBox.Show("Hasta güncellenemedi");
                }
                else
                {
                    MessageBox.Show("Diyet başarılı bir şekilde oluşturuldu");
                    //KullaniciEkrani sayfasına git
                    KullaniciEkrani frm = new KullaniciEkrani();
                    frm.Show();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Diyet oluşturulamadı");
            }
        }

       

        private void DiyetEkle_Load(object sender, EventArgs e)
        {
            GetDietMethods();
            GetDieticianPatients();
        }
        private async void GetDieticianPatients()
        {
            HttpClient _client = new HttpClient();
            _patientService = new PatientService(_client);
            BaseResponse<Patient> response = await _patientService.GetAllPatientByDietician(Program.DieticianId);
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                Dictionary<string, string> patients = new Dictionary<string, string>();
                foreach (var item in response.Content)
                {
                    patients.Add(item.Id, item.Name + " " + item.LastName);
                }
                cmb_box_patients.DataSource = new BindingSource(patients, null);
                cmb_box_patients.DisplayMember = "Value";
                cmb_box_patients.ValueMember = "Key";
            }
            else
            {
                MessageBox.Show("Hastalar getirilemedi");
            }

        }

        private async void GetDietMethods()
        {
            HttpClient _client = new HttpClient();
            _dietMethodService = new DietMethodService(_client);
            BaseResponse<DietMethod> response = await _dietMethodService.GetAllDietMethod();
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                Dictionary<string, string> dietmethods = new Dictionary<string, string>();
                foreach (var item in response.Content)
                {
                    dietmethods.Add(item.Id,item.Name);
                }
                cmb_box_dietmethod.DataSource = new BindingSource(dietmethods, null);
                cmb_box_dietmethod.DisplayMember = "Value";
                cmb_box_dietmethod.ValueMember = "Key";
            }
            else
            {
                MessageBox.Show("Diyet metotları getirilemedi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //KullaniciEkrani sayfasına git
            KullaniciEkrani frm = new KullaniciEkrani();
            frm.Show();
            this.Close();

        }
    }
}
