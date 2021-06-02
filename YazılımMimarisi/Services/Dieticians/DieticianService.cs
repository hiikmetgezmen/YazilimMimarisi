using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımMimarisi.Extensions;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi.Services.Dieticians
{
    public class DieticianService : IDieticianService
    {
        private readonly HttpClient _client;


        public DieticianService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<BaseResponse<Dietician>> GetAllDietician()
        {

            try
            {
                var response = await _client.GetAsync($"/api/v1/Dietician/");
                return await response.ReadContentAs<BaseResponse<Dietician>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Dietician>> GetDietician(string id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Dietician/{id}");
                return await response.ReadContentAs<BaseResponse<Dietician>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Dietician>> CreateDietician(Dietician model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<Dietician>("/api/v1/Dietician/", model);
                return await response.ReadContentAs<BaseResponse<Dietician>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Dietician>> UpdateDietician(Dietician model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync<Dietician>("/api/v1/Dietician/", model);
                return await response.ReadContentAs<BaseResponse<Dietician>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Dietician>> Login(Dietician model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<Dietician>("/api/v1/Dietician/GetLogin", model);
                return await response.ReadContentAs<BaseResponse<Dietician>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

       
    }
}
