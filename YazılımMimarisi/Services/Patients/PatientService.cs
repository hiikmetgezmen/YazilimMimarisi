using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımMimarisi.Extensions;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi.Services.Patients
{
    public class PatientService :IPatientService
    {
        private readonly HttpClient _client;


        public PatientService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<BaseResponse<Patient>> GetAllPatient()
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Patient/");
                return await response.ReadContentAs<BaseResponse<Patient>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Patient>> GetPatient(string id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Patient/{id}");
                return await response.ReadContentAs<BaseResponse<Patient>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
        public async Task<BaseResponse<Patient>> GetAllPatientByDietician(string dieticianId)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Patient/dieticianid/{dieticianId}");
                return await response.ReadContentAs<BaseResponse<Patient>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
        public async Task<BaseResponse<Patient>> CreatePatient(Patient model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<Patient>("/api/v1/Patient/", model);
                return await response.ReadContentAs<BaseResponse<Patient>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Patient>> DeletePatient(Patient model)
        {
            try
            {
                var response = await _client.DeleteAsJsonAsync($"/api/v1/Patient/{model.Id}");
                return await response.ReadContentAs<BaseResponse<Patient>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Patient>> UpdatePatient(Patient model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"/api/v1/Patient/",model);
                return await response.ReadContentAs<BaseResponse<Patient>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }


    }
}
