using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NOTICE_ME_DOMAIN.Entities.User;
using NOTICE_ME_SERVICE.ApplicationService.Config.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NOTICE_ME_SERVICE.ApplicationService.Config
{
    public class TokenApplicationService : ITokenApplicationService
    {

        private readonly IConfiguration configuration;

        public TokenApplicationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfiguration:Secret").Value);
            var tokenDescriptor =
                new SecurityTokenDescriptor
                {
                    Subject =
                        new ClaimsIdentity(
                            new Claim[] {
                                new Claim(ClaimTypes.NameIdentifier, user.Email.ToString()),
                                new Claim(ClaimTypes.Name, user.Email.ToString())

                            }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Expires = DateTime.UtcNow.AddHours(24)

                };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
