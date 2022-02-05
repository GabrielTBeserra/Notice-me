using NOTICE_ME_COMMON.Exceptions;
using NOTICE_ME_COMMON.Helpers.ConvertContext;
using NOTICE_ME_CROSSCUTING.DTO.User;
using NOTICE_ME_DOMAIN.Entities.User;
using NOTICE_ME_INFRASTRUCTURE.UnitOfWork.User.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Auth.Interfaces;
using NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOTICE_ME_SERVICE.ApplicationService.Auth
{
    public class AuthApplicationService : IAuthApplicationService
    {
        private readonly IAuthUnitOfWork _uow;
        private readonly ITokenApplicationService tokenApplicationService;

        public AuthApplicationService(IAuthUnitOfWork uow, ITokenApplicationService tokenApplicationService)
        {
            _uow = uow;
            this.tokenApplicationService = tokenApplicationService;
        }

        public async Task<LoginResponseDto> Login(LoginDto dto, CancellationToken ctToken = default)
        {
            ctToken.ThrowIfCancellationRequested();

            var password = dto.Password.ToSha256();
            var user = _uow.UserRepository.GetUntracked()
                        .Where(user => user.Email == dto.Email && user.Password == password)
                        .FirstOrDefault();

            if (user == null)
            {
                throw new DomainException("User not registered.");
            }


            var userLogged = new LoginResponseDto
            {
                Token = tokenApplicationService.GenerateToken(user)
            };

            return userLogged;
        }

        public async Task Register(RegisterDto dto, CancellationToken ctToken = default)
        {
            ctToken.ThrowIfCancellationRequested();

            var user = _uow.UserRepository.GetUntracked()
                        .Where(user => user.Email == dto.Email)
                        .FirstOrDefault();

            if (user != null)
            {
                throw new DomainException("User already registered.");
            }

            var newUser = new UserEntity
            {
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password.ToSha256()
            };

            await _uow.UserRepository.AddAsync(newUser);

            await _uow.CommitAsync();
        }

    }
}
