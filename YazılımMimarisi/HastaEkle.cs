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
using YazılımMimarisi.Models.Entities.Diseases;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.Diseases;
using YazılımMimarisi.Services.Interfaces;
using YazılımMimarisi.Services.Patients;

namespace YazılımMimarisi
{
    public partial class HastaEkle : Form
    {
        private IPatientService _patientService;
        private IDiseaseService _diseaseService;
        
        public HastaEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                //KullaniciEkrani sayfasına git
                KullaniciEkrani frm = new KullaniciEkrani();
                frm.Show();
                this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txt_tcno.Text == "" || txt_name.Text == "" || txt_surname.Text == "" || txt_email.Text == "" || cmbox_disease.Text == "")
            {
                MessageBox.Show("Lütfen boş kutu bırakmayınız...");
            }
            else
            {
                HttpClient _client = new HttpClient();
                _patientService = new PatientService(_client);
                Contact contact = new Contact() { Email = txt_email.Text };
                Patient patient = new Patient() {IDNumber=txt_tcno.Text,Name=txt_name.Text,LastName=txt_surname.Text, Contact = contact, DiseaseIds = new List<string>() { ((KeyValuePair<string, string>)cmbox_disease.SelectedItem).Key },DieticianId=Program.DieticianId };
                BaseResponse<Patient> response = await _patientService.CreatePatient(patient);
                if (response.Status.Value == ResponseStatus.Success.Value)
                {
                    KullaniciEkrani frm = new KullaniciEkrani();
                    frm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hasta oluşturulamadı bilgileri doğru girdiğinizden emin olun.");
                }
            }
        }

        private  void HastaEkle_Load(object sender, EventArgs e)
        {
            DiseaseCmbBoxLoader();
        }
        
        private async void DiseaseCmbBoxLoader()
        {
            HttpClient _client = new HttpClient();
            _diseaseService = new DiseaseService(_client);
            BaseResponse<Disease> response = await _diseaseService.GetAllDisease();
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                if (response.Content.Count > 0)
                {
                    Dictionary<string, string> disease = new Dictionary<string, string>();
                    foreach (var item in response.Content)
                    {
                        disease.Add(item.Id, item.Name);
                    }
                    cmbox_disease.DataSource = new BindingSource(disease, null);
                    cmbox_disease.DisplayMember = "Value";
                    cmbox_disease.ValueMember = "Key";
                }
            }
            else
            {
                MessageBox.Show("API Hastalıkları çekerken bir hata oluştu");
            }
        }
    }
}
