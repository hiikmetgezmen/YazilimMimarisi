using System.Threading.Tasks;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Diets;

namespace YazılımMimarisi.Services.Interfaces
{
    public interface IFoodService
    {
        Task<BaseResponse<Food>> GetFood(string id);
        Task<BaseResponse<Food>> GetAllFood();
        Task<BaseResponse<Food>> UpdateFood(Food model);
        Task<BaseResponse<Food>> CreateFood(Food model);
        Task<BaseResponse<Food>> GetFoodByTag(string tag);
    }
}
