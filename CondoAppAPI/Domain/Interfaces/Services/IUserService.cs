using Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login([FromBody] LoginRequest model);
    }
}
