using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Domain.Enums;
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
        private readonly IRepository<Role> _repositoryRole;

        public AuthenticationService(IRepository<User> repository, IConfiguration configuration, IRepository<Role> repositoryRole) : this(repository, configuration)
        {
            _repositoryRole = repositoryRole;
        }

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
            user.Roles =await _repositoryRole.SelectByIdAsync(user.RoleId);
            return new LoginResultDto
            {
                Token = GenerateToken(user)
            };
        }

        private string GenerateToken(User user)
        {
           var tokenHandler = new JwtSecurityTokenHandler();
           var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim("Id",user.Id.ToString()),
                   new Claim("Email",user.Email),
                   new Claim(ClaimTypes.Role,user.Roles.Name),
        }),
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issuer"],
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
