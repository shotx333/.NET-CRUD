
using DataAccessLayer.Models.DatabaseModels;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<DBUser> GetAll();
        DBUser GetById(int id);
        void Insert(DBUser user);
        void Update(int id, DBUser user);
        void Delete(int id);
    }
}
