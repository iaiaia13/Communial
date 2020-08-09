using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NetCoreData.Models;
using NetCoreData.ReposInterface;
using NetCoreServer.Services;
using NetCoreServer.ViewModels;
using System;
using System.Threading.Tasks;

namespace NetCoreServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IUserRepository _userRepository;

        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            this._authService = authService;
            this._userRepository = userRepository;
        }

        [HttpPost("login")]
        public ActionResult<AuthData> Post([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userRepository.GetUser(u => u.Email == model.Email);

            if (user == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            var authData = _authService.GenerateToken(user.GUID);
            return new OkObjectResult(authData);
        }

        [HttpPost("register")]
        public ActionResult<AuthData> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var emailUniq = _userRepository.isEmailUniq(model.Email);
            if (!emailUniq)
                return BadRequest(new { email = "user with this email already exists" });

            var usernameUniq = _userRepository.IsUsernameUniq(model.Username);
            if (!usernameUniq)
                return BadRequest(new { username = "user with this email already exists" });

            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Password = _authService.HashPassword(model.Password)
            };
            _userRepository.InsertUser(user);

            var authData = _authService.GenerateToken(user.GUID);
            return new OkObjectResult(authData);
        }

        [AllowAnonymous]
        [HttpPost("google")]
        public async Task<IActionResult> Google([FromBody] AuthData authData)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(authData.Token, new GoogleJsonWebSignature.ValidationSettings());

                var user = _userRepository.GetUser(x => x.Email == payload.Email);

                if (user == null)
                {
                    user = new User
                    {
                        UserName = payload.GivenName,
                        Email = payload.Email,
                        Name = payload.GivenName + " " + payload.FamilyName,
                    };
                    _userRepository.InsertUser(user);
                }

                var token = _authService.GenerateToken(user.GUID);
                user.Token = token.Token;
                user.TokenExpirationTime = token.TokenExpirationTime;
                _userRepository.UpdateUser(user);

                return new OkObjectResult(token);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return BadRequest();
        }
    }
}