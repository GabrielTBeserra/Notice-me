using NOTICE_ME_CROSSCUTING.DTO.Auth;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Auth.Interfaces
{
    public interface IAuthApplicationService
    {
        Task<LoginResponseDto> Login(LoginDto dto);
        Task Register(RegisterDto dto);
    }
}
