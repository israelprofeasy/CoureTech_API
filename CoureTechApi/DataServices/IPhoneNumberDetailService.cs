using CoureTechApi.Models.DTOs;
using System.Threading.Tasks;

namespace CoureTechApi.DataServices
{
    public interface IPhoneNumberDetailService
    {
        Task<ResponseDTO> RetreiveInformation(long phoneNumber);
    }
}
