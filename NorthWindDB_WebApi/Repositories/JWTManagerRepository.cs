using JWTWebAuthentication.Repository;
using NorthWindDB_WebApi.Entities;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using NorthWindDB_WebApi.Repositories.Contracts;

namespace NorthWindDB_WebApi
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public JWTManagerRepository(IConfiguration iconfiguration, IUserRepository userRepository)
        {
            _configuration = iconfiguration;
            _userRepository = userRepository;
        }
        public Tokens Authenticate(Users users)
        {
            if (!_userRepository.ValidateUser(users.Name, users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, users.Name)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}