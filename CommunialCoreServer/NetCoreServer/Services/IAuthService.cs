using NetCoreData.Models;
using NetCoreData.ReposInterface;
using NetCoreServer.ViewModels;

namespace NetCoreServer.Services
{
    public interface IAuthService
    {
        public AuthData GenerateToken(string id);

        public Users GetAuthData(IUsersRepository userRepository, string email);

        public string HashPassword(string password);

        public bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}