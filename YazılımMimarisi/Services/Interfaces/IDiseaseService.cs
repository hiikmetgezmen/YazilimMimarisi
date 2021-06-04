using System.Threading.Tasks;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Diseases;

namespace YazılımMimarisi.Services.Interfaces
{
    public interface IDiseaseService
    {
        Task<BaseResponse<Disease>> GetDisease(string id);
        Task<BaseResponse<Disease>> GetAllDisease();
        Task<BaseResponse<Disease>> DeleteDisease(Disease model);
        Task<BaseResponse<Disease>> CreateDisease(Disease model);
    }
}
