using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Diets;

namespace YazılımMimarisi.Services.Interfaces
{
    public interface IDietMethodService
    {
        Task<BaseResponse<DietMethod>> GetDietMethod(string id);
        Task<BaseResponse<DietMethod>> GetAllDietMethod();
        Task<BaseResponse<DietMethod>> UpdateDietMethod(DietMethod model);
        Task<BaseResponse<DietMethod>> CreateDietMethod(DietMethod model);
    }
}
