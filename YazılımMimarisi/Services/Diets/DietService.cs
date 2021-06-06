using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımMimarisi.Extensions;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Diets;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi.Services.Diets
{
    public class DietService:IDietService
    {
        private readonly HttpClient _client;

        public DietService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BaseResponse<Diet>> GetAllDiet()
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Diet/");
                return await response.ReadContentAs<BaseResponse<Diet>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Diet>> GetDiet(string id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Diet/{id}");
                return await response.ReadContentAs<BaseResponse<Diet>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
        public async Task<BaseResponse<Diet>> CreateDiet(Diet model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<Diet>("/api/v1/Diet/", model);
                return await response.ReadContentAs<BaseResponse<Diet>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Diet>> UpdateDiet(Diet model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync<Diet>("/api/v1/Diet/", model);
                return await response.ReadContentAs<BaseResponse<Diet>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
    }
}
