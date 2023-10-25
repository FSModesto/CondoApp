using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginResponse> Login([FromBody] LoginRequest model)
        {
            User user = await _repository.Find(wh => wh.Email == model.Email);

            if (user is null)
                throw new Exception("Usuário ou senha inválidos");

            if (user.Password != model.Password)
                throw new Exception("Usuário ou senha inválidos");

            var token = GenerateToken();

            LoginResponse response = new LoginResponse()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Token = token,
            };

            return response;
        }

        private string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ZmVkYWY3ZDg4NjNiNDhlMTk3YjkyODdkNDkyYjcwOGU=");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
