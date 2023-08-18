using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Exceptions;
using OLXWebApi.Services.IService;
using OLXWebApi.Shared.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OLXWebApi.Services.Service
{
    public class AuthenticationService : IAuthService
    {
        private readonly IRepository<User> _repository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IRepository<User> repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async ValueTask<LoginResultDto> AuthenticateAsync(LoginDto dto)
        {
           var user = await this._repository.SelectAll()
                .FirstOrDefaultAsync(user => user.Email == dto.Email);
            if (user == null || !PasswordHelper.Verify(dto.Password, user.Password))
                throw new OlxException(400, "Email or password is incorrect");

            return new LoginResultDto
            {
                Token = GenerateToken(user)
            };
        }

        private string GenerateToken(User user)
        {
           var tokenHandler = new JwtSecurityTokenHandler();
           var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            //string v = user.Role.Name.ToString();
            //Console.WriteLine(v);
            var tokenDescriptor = new SecurityTokenDescriptor
           {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim("Id",user.Id.ToString()),
                   new Claim(ClaimTypes.Role,user.Role.ToString()),
        }),
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issure"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
