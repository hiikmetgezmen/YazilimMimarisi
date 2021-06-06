using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımMimarisi.Extensions;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Diets;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi.Services.DietMethods
{
    public class DietMethodService : IDietMethodService
    {
        private readonly HttpClient _client;

        public DietMethodService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BaseResponse<DietMethod>> GetAllDietMethod()
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/DietMethod");
                return await response.ReadContentAs<BaseResponse<DietMethod>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<DietMethod>> GetDietMethod(string id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/DietMethod/{id}");
                return await response.ReadContentAs<BaseResponse<DietMethod>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<DietMethod>> CreateDietMethod(DietMethod model)
        {

            try
            {
                var response = await _client.PostAsJsonAsync<DietMethod>("/api/v1/DietMethod/", model);
                return await response.ReadContentAs<BaseResponse<DietMethod>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<DietMethod>> UpdateDietMethod(DietMethod model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync<DietMethod>("/api/v1/DietMethod/", model);
                return await response.ReadContentAs<BaseResponse<DietMethod>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
    }
}
