using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DBUser>> GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<DBUser> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult PutUser(int id, DBUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userService.UpdateUser(id,user);
            return NoContent();
        }


        [HttpPost]
        public ActionResult<DBUser> PostUser(DBUser user)
        {
            _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public ActionResult<DBUser> DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(id);
            return user;
        }
    }
}

