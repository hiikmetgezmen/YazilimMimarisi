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
using YazılımMimarisi.Models.Entities.Diseases;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi.Services.Diseases
{
    public class DiseaseService : IDiseaseService
    {
        private readonly HttpClient _client;


        public DiseaseService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BaseResponse<Disease>> GetAllDisease()
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Disease/");
                return await response.ReadContentAs<BaseResponse<Disease>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Disease>> GetDisease(string id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Disease/{id}");
                return await response.ReadContentAs<BaseResponse<Disease>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Disease>> CreateDisease(Disease model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<Disease>("/api/v1/Disease/", model);
                return await response.ReadContentAs<BaseResponse<Disease>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Disease>> DeleteDisease(Disease model)
        {
            try
            {
                var response = await _client.DeleteAsJsonAsync($"/api/v1/Disease/{model.Id}");
                return await response.ReadContentAs<BaseResponse<Disease>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

      
    }
}
