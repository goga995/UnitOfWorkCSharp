using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Core.IConfiguration;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(
            ILogger<UsersController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if(ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();

                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsynch();

                return CreatedAtAction("GetItem", new{user.Id}, user);
            }
            return new JsonResult("Somthing went Wrong"){StatusCode = 500};
        }
        //GetByID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if(user == null)
            {
                return NotFound();//404
            }
            return Ok(user);
        }
        //Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.Users.All();
            return Ok(users);
        }
        //Update
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }
            await _unitOfWork.Users.Upsert(user);
            await _unitOfWork.CompleteAsynch();

            return NoContent(); // Standard for update
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _unitOfWork.Users.GetById(id);
            if(item == null)
            {
                return BadRequest();
            }
            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.CompleteAsynch();
            
            return Ok(item);
        }
    }
}