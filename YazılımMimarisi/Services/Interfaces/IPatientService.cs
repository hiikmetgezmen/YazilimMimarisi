using System.Threading.Tasks;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Persons;

namespace YazılımMimarisi.Services.Interfaces
{
    public interface IPatientService
    {
        Task<BaseResponse<Patient>> GetPatient(string id);
        Task<BaseResponse<Patient>> GetAllPatientByDietician(string dieticianId);
        Task<BaseResponse<Patient>> GetAllPatient();
        Task<BaseResponse<Patient>> DeletePatient(Patient model);
        Task<BaseResponse<Patient>> CreatePatient(Patient model);
        Task<BaseResponse<Patient>> UpdatePatient(Patient model);
    }
}
