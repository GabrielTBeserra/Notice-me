using NOTICE_ME_CROSSCUTING.DTO.User;
using System.Threading;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Auth.Interfaces
{
    public interface IAuthApplicationService
    {
        Task<LoginResponseDto> Login(LoginDto dto, CancellationToken ctToken);
        Task Register(RegisterDto dto, CancellationToken ctToken);
    }
}
