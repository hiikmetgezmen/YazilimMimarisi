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

namespace YazılımMimarisi.Services.Admins
{
    public class AdminService: IAdminService
    {
        private readonly HttpClient _client;


        public AdminService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BaseResponse<Admin>> GetAdmin(string id)
        {
            _client.BaseAddress =new Uri( "http://localhost:5000");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await _client.GetAsync($"/api/v1/Admin/{id}");
                return await response.ReadContentAs<BaseResponse<Admin>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
        public async Task<Admin> UpdateAdmin(Admin model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync<Admin>("/api/v1/Admin/", model);
                return await response.ReadContentAs<Admin>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
