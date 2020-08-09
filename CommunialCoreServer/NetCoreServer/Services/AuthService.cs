using Microsoft.IdentityModel.Tokens;
using NetCoreData.Models;
using NetCoreData.ReposInterface;
using NetCoreServer.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCoreServer.Services
{
    public class AuthService : IAuthService
    {
        private string jwtSecret;
        private int jwtLifespan;

        public AuthService(string jwtSecret, int jwtLifespan)
        {
            this.jwtSecret = jwtSecret;
            this.jwtLifespan = jwtLifespan;
        }

        public AuthData GenerateToken(string id)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = id,
            };
        }

        public User GetAuthData(IUserRepository userRepository, string email)
        {
            var user = userRepository.GetUser(x => x.Email == email);
            if (user == null)
            {
                user = new User
                {
                    Email = email,
                    UserName = email,
                };
                userRepository.InsertUser(user);
            }

            return user;
        }

        public string HashPassword(string password)
        {
            return PasswordHasher.Hash(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return PasswordHasher.Check(actualPassword, hashedPassword);
        }
    }
}