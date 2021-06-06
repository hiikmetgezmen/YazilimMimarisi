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
using YazılımMimarisi.Models.Entities.Diets;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi.Services.Foods
{
    public class FoodService :IFoodService
    {
        private readonly HttpClient _client;

        public FoodService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BaseResponse<Food>> GetAllFood()
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Food");
                return await response.ReadContentAs<BaseResponse<Food>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Food>> GetFood(string id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Food/{id}");
                return await response.ReadContentAs<BaseResponse<Food>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Food>> GetFoodByTag(string tag)
        {
            try
            {
                var response = await _client.GetAsync($"/api/v1/Food/{tag}");
                return await response.ReadContentAs<BaseResponse<Food>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Food>> CreateFood(Food model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync<Food>("/api/v1/Food/", model);
                return await response.ReadContentAs<BaseResponse<Food>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public async Task<BaseResponse<Food>> UpdateFood(Food model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync<Food>("/api/v1/Food/", model);
                return await response.ReadContentAs<BaseResponse<Food>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

     
    }
}
