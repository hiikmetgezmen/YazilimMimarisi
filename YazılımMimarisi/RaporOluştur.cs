using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Common.Enums;
using YazılımMimarisi.Models.Entities.Diets;
using YazılımMimarisi.Models.Entities.Diseases;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.DietMethods;
using YazılımMimarisi.Services.Diets;
using YazılımMimarisi.Services.Diseases;
using YazılımMimarisi.Services.Foods;
using YazılımMimarisi.Services.Interfaces;
using YazılımMimarisi.Services.Patients;

namespace YazılımMimarisi
{
    public partial class RaporOluştur : Form
    {
        private IPatientService _patientService;
        private IDiseaseService _diseaseService;
        private IDietService _dietService;
        private IDietMethodService _dietMethodService;
        private IFoodService _foodService;
        public RaporOluştur()
        {
            InitializeComponent();
        }

     

        private void RaporOluştur_Load(object sender, EventArgs e)
        {
            GetDieticianPatients();
        }
      

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient _client = new HttpClient();
            _patientService = new PatientService(_client);
            BaseResponse<Patient> patientMethodResponse = await _patientService.GetPatient(((KeyValuePair<string, string>)cmb_box_patients.SelectedItem).Key);
            if (patientMethodResponse.Status.Value==ResponseStatus.Success.Value)
            {
                Patient patient = patientMethodResponse.Content[0];
                List<string> foods = new List<string>();
                _client = new HttpClient();
                _dietService = new DietService(_client);
                BaseResponse<Diet> dietResponse = await _dietService.GetDiet(patient.DietId);
                if (dietResponse.Status.Value == ResponseStatus.Success.Value)
                {
                    _client = new HttpClient();
                    _diseaseService = new DiseaseService(_client);
                    BaseResponse<Disease> diseaseResponse = await _diseaseService.GetDisease(patient.DiseaseIds[0]);
                    _client = new HttpClient();
                    _foodService = new FoodService(_client);
                    foreach (var item in dietResponse.Content[0].DietFoodList)
                    {
                        BaseResponse<Food> foodResponse = await _foodService.GetFood(item);
                        foods.Add(foodResponse.Content[0].Name);
                    }
                    _client = new HttpClient();
                    _dietMethodService = new DietMethodService(_client);
                    BaseResponse<DietMethod> dietMethodService = await _dietMethodService.GetDietMethod(dietResponse.Content[0].DietMethodId);
                    if (rd_btn_html.Checked)
                    {
                        WriteHTMLFile("Rapor.html", patient, diseaseResponse.Content[0], dietResponse.Content[0], dietMethodService.Content[0],foods);
                    }
                    else if (rd_btn_json.Checked)
                    {
                        WriteJSONFile("Rapor.json", patient, diseaseResponse.Content[0], dietResponse.Content[0], dietMethodService.Content[0], foods);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen çıktı türünü seçiniz.");
                    }
                }
                
            }
           
        }
        private void WriteHTMLFile(string filename, Patient patient,Disease disease,Diet diet,DietMethod dietMethod,List<string> foods)
        {
            string textlist = "<h3>Diyet İçeriği</h3><ul>";
            foreach (var item in foods)
            {
                textlist += "<li>" + item + "</li>";
            }
            textlist += "</ul></body></html>";
            string[] text = {"<!DOCTYPE html><html lang=\"tr\">",
                "<head><meta charset=\"UTF-8\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"><title>Rapor</title></head>",
                $"<body><h1>Rapor</h1><h3>Hasta Bilgileri</h3>",
                "<table>",
                "<tr>",
                "<th>TC Numarası</th>",
                "<th>Ad</th>",
                "<th>Soyad</th>",
                "<th>Hastalık</th>",
                "</tr>",
                "<tr>",
                $"<td>{patient.IDNumber}</td>",
                $"<td>{patient.Name}</td>",
                $"<td>{patient.LastName}</td>",
                $"<td>{disease.Name}</td>",
                "</tr>",
                "</table>",
                "<h3>Diet Bilgileri</h3>",
                $"<p><b>Diet Yöntemi:</b>{dietMethod.Name}</p>",
                $"<p><b>Diet Yöntemi Açıklaması:</b>{dietMethod.Description}</p>",
                $"<p><b>Diet Başlangıç Tarihi:</b>{diet.StartDate} </p>",
                $"<p><b>Diet Başlangıç Tarihi:</b>{diet.EndDate} </p>",
                textlist
            };
            try
            {
                File.WriteAllLines(filename, text);
                MessageBox.Show("Rapor Oluşturuldu");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Rapor oluşturulamadı: "+ex.Message);
            }
       
        }
        private void WriteJSONFile(string filename, Patient patient, Disease disease, Diet diet, DietMethod dietMethod, List<string> foods)
        {
            string textlist = "\"DiyetIcerigi\":[";
            foreach (var item in foods)
            {
                textlist += "\"" + item + "\",";
            }
            textlist += "]}";
            string[] text = {
                    "{\"TCNumarasi\":\""+patient.IDNumber+"\",",
                    "\"Adi\":\""+patient.Name+"\",",
                    "\"Soyadi\":\""+patient.LastName+"\",",
                    "\"Hastalik\":\""+disease.Name+"\",",
                    "\"DiyetMetodu\":\""+dietMethod.Name+"\",",
                    "\"DiyetMetoduAciklamasi\":\""+dietMethod.Description+"\",",
                    "\"DiyetBaslangicTarihi\":\""+diet.StartDate+"\",",
                    "\"DiyetBitisTarihi\":\""+diet.EndDate+"\",",
                    textlist
                };
            try
            {
                File.WriteAllLines(filename, text);
                MessageBox.Show("Rapor Oluşturuldu");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Rapor oluşturulamadı: " + ex.Message);
            }
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
    }
}
