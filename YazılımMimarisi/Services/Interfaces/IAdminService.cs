using System.Threading.Tasks;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Persons;

namespace YazılımMimarisi.Services.Interfaces
{
    public interface IAdminService
    {
        Task<BaseResponse<Admin>> GetAdmin(string id);
        Task<Admin> UpdateAdmin(Admin model);
    }
}
