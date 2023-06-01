using DataAccessLayer.Models.DatabaseModels;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUserProfileService
    {
        IQueryable<UserProfile> GetUserProfiles();
        UserProfile GetUserProfileByUserId(int userId);
        void CreateUserProfile(UserProfile userProfile);
        void UpdateUserProfile(int id,UserProfile userProfile);
        void DeleteUserProfile(int id);
    }

}
