using DataAccessLayer.Models.DatabaseModels;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<DBUser> GetAllUsers();
        DBUser GetUserById(int id);
        DBUser CreateUser(DBUser user);
        void UpdateUser(int id, DBUser user);
        void DeleteUser(int id);
    }

}
