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
     * FoodsController.cs expose Async API Endpoints for CRUD operations on Users
     */
    public class FoodsController : ControllerBase
    {
        private IFoodRepository _foodRepository;

        public FoodsController(IFoodRepository foodRepository)
        {
            this._foodRepository = foodRepository;
        }

        // GET api/foods
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _foodRepository.GetAllFood();
            return new OkObjectResult(result);
        }

        // GET api/foods/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var result = _foodRepository.GetOneFood(id);

            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/foods
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Food body)
        {
            _foodRepository.InsertNewFood(body);
            var result = _foodRepository.GetOneFood(body.ID);
            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // PUT api/foods/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutOne(int id, [FromBody] Food body)
        {
            Food food = _foodRepository.GetOneFood(id);
            if (food is null)
                return new NotFoundResult();
            body.ID = id;
            _foodRepository.UpdateOneFood(body);

            var result = _foodRepository.GetAllFood();
            return new OkObjectResult(result);
        }

        // DELETE api/foods/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteOne(int id)
        {
            var food = _foodRepository.GetOneFood(id);

            if (food is null)
                return new NotFoundResult();
            _foodRepository.DeleteOneFoodByID(id);

            var result = _foodRepository.GetAllFood();
            return new OkObjectResult(result);
        }

        // DELETE api/foods
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteAll()
        {
            var result = _foodRepository.GetAllFood();
            return new OkObjectResult(result);
        }
    }
}