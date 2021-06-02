using System.Threading.Tasks;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Persons;

namespace YazılımMimarisi.Services.Interfaces
{
    public interface IDieticianService
    {
        Task<BaseResponse<Dietician>> GetDietician(string id);
        Task<BaseResponse<Dietician>> GetAllDietician();
        Task<BaseResponse<Dietician>> UpdateDietician(Dietician model);
        Task<BaseResponse<Dietician>> CreateDietician(Dietician model);
        Task<BaseResponse<Dietician>> Login(Dietician model);
    }
}
