using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Models.DatabaseModels;

namespace BusinessLogicLayer.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public IQueryable<UserProfile> GetUserProfiles()
        {
            return _userProfileRepository.GetUserProfiles();
        }

        public UserProfile GetUserProfileByUserId(int id)
        {
            return _userProfileRepository.GetUserProfile(id);
        }

        public void CreateUserProfile(UserProfile userProfile)
        {
            _userProfileRepository.CreateUserProfile(userProfile);
        }

        public void UpdateUserProfile(int id, UserProfile userProfile)
        {
            _userProfileRepository.UpdateUserProfile(id, userProfile);
        }

        public void DeleteUserProfile(int id)
        {
            _userProfileRepository.DeleteUserProfile(id);
        }
    }
}
