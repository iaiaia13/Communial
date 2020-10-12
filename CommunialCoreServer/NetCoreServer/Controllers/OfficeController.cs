using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NetCoreData.Models;
using NetCoreData.ReposInterface;
using NetCoreServer.Services;
using NetCoreServer.ViewModels;
using System;

namespace NetCoreServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    /*
     * FoodsController.cs expose Async API Endpoints for CRUD operations on Users
     */
    public class OfficeController : ControllerBase
    {
        private IOfficeRepository _officeRepository;
        private IOfficeService _officeservice;

        public OfficeController(IOfficeRepository foodRepository, IOfficeService officeservice)
        {
            this._officeRepository = foodRepository;
            _officeservice = officeservice;
        }

        // GET api/foods
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _officeRepository.GetAllFood();
            return new OkObjectResult(result);
        }

        // POST api/foods
        [HttpPost("search")]
        public IActionResult Search([FromBody] OfficeFilterViewModel body)
        {
            var result = _officeservice.Search(body);
            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // GET api/foods/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetOne(string id)
        {
            var result = _officeRepository.GetOneFood(id);

            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/foods
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Office body)
        {
            _officeRepository.InsertNewFood(body);
            var result = _officeRepository.GetOneFood(body.ID);
            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // PUT api/foods/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutOne(string id, [FromBody] Office body)
        {
            Office food = _officeRepository.GetOneFood(id);
            if (food is null)
                return new NotFoundResult();
            body.ID = id;
            _officeRepository.UpdateOneFood(body);

            var result = _officeRepository.GetAllFood();
            return new OkObjectResult(result);
        }

        // DELETE api/foods/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteOne(string id)
        {
            var food = _officeRepository.GetOneFood(id);

            if (food is null)
                return new NotFoundResult();
            _officeRepository.DeleteOneFoodByID(id);

            var result = _officeRepository.GetAllFood();
            return new OkObjectResult(result);
        }

        // DELETE api/foods
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteAll()
        {
            var result = _officeRepository.GetAllFood();
            return new OkObjectResult(result);
        }
    }
}