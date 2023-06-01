using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfilesController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]

        public ActionResult<IQueryable<UserProfile>> getUserProfiles()
        {
            return Ok(_userProfileService.GetUserProfiles());
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
        {
            var userProfile = _userProfileService.GetUserProfileByUserId(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return userProfile;
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            _userProfileService.UpdateUserProfile(id,userProfile);
         

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
        {
             _userProfileService.CreateUserProfile(userProfile);

            return CreatedAtAction("GetUserProfile", new { id = userProfile.Id }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserProfile>> DeleteUserProfile(int id)
        {
            var userProfile = _userProfileService.GetUserProfileByUserId(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            _userProfileService.DeleteUserProfile(id);

            return userProfile;
        }

      
    }
   
}
