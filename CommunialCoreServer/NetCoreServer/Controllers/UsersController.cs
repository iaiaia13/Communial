using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NetCoreData.Models;
using NetCoreData.ReposInterface;

namespace NetCoreServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    /*
     * UsersController.cs expose Async API Endpoints for CRUD operations on Users
     */
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        // GET api/users
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userRepository.GetAllUsers();
            return new OkObjectResult(result);
        }

        // GET api/users/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetOne(string id)
        {
            var result = _userRepository.GetUser(id);

            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/users
        //[Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] User body)
        {
            _userRepository.InsertUser(body);
            var user = _userRepository.GetUser(body.UserName);
            if (user is null)
                return new NotFoundResult();

            return new OkObjectResult(user);
        }

        // PUT api/users/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutOne(string username, [FromBody] User body)
        {
            User user = _userRepository.GetUser(username);
            if (user is null)
                return new NotFoundResult();
            body.UserName = username;
            _userRepository.UpdateUser(body);

            var result = _userRepository.GetAllUsers();
            return new OkObjectResult(result);
        }

        // DELETE api/users/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteOne(string id)
        {
            var user = _userRepository.GetUser(id);

            if (user is null)
                return new NotFoundResult();
            _userRepository.DeleteUser(id);

            var result = _userRepository.GetAllUsers();
            return new OkObjectResult(result);
        }

        // DELETE api/users
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            var result = _userRepository.GetAllUsers();
            return new OkObjectResult(result);
        }
    }
}