using DataAccessLayer.Models.DatabaseModels;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DBUser> GetAll()
        {
            return _context.Users.Include(u => u.UserProfile);
        }

        public DBUser GetById(int id)
        {
            return _context.Users.Include(u => u.UserProfile).FirstOrDefault(u => u.Id == id);
        }

        public void Insert(DBUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id,DBUser user)
        {
            var existingUser = _context.Users.Find(id) ?? throw new ArgumentException("User with the provided id could not be found", nameof(id));

         
            _context.Entry(existingUser).CurrentValues.SetValues(user);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

}
