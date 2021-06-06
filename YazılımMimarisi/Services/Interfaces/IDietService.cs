using System.Threading.Tasks;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Diets;

namespace YazılımMimarisi.Services.Interfaces
{
    public interface IDietService
    {
        Task<BaseResponse<Diet>> GetDiet(string id);
        Task<BaseResponse<Diet>> GetAllDiet();
        Task<BaseResponse<Diet>> UpdateDiet(Diet model);
        Task<BaseResponse<Diet>> CreateDiet(Diet model);
    }
}
