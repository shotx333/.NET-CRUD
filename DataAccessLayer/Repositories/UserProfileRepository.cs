using DataAccessLayer.Models.DatabaseModels;
using DataAccessLayer.Repositories.Interfaces;


namespace DataAccessLayer.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly UserDbContext _context;

        public UserProfileRepository(UserDbContext context)
        {
            _context = context;
        }

        public IQueryable<UserProfile> GetUserProfiles()
        {
            return _context.UserProfiles;
        }

        public UserProfile GetUserProfile(int id)
        {
            return _context.UserProfiles.FirstOrDefault(x => x.Id == id);
        }

        public void CreateUserProfile(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            _context.SaveChanges();
        }

        public void UpdateUserProfile(int id, UserProfile userProfile)
        {
            var existingUserProfile = _context.UserProfiles.Find(id);
            if (existingUserProfile == null) return;

            _context.Entry(existingUserProfile).CurrentValues.SetValues(userProfile);
            _context.SaveChanges();
        }

        public void DeleteUserProfile(int id)
        {
            var userProfileToDelete = _context.UserProfiles.Find(id);
            if (userProfileToDelete == null) return;

            _context.UserProfiles.Remove(userProfileToDelete);
            _context.SaveChanges();
        }
    }
}
