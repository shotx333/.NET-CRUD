
using DataAccessLayer.Models.DatabaseModels;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserProfileRepository
    {
        IQueryable<UserProfile> GetUserProfiles();
        UserProfile GetUserProfile(int id);
        void CreateUserProfile(UserProfile userProfile);
        void UpdateUserProfile(int id, UserProfile userProfile);
        void DeleteUserProfile(int id);
    }
}
