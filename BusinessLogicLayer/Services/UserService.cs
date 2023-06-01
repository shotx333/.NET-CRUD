using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models.DatabaseModels;
using DataAccessLayer.Repositories.Interfaces;


namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<DBUser> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public DBUser GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public DBUser CreateUser(DBUser user)
        {
            _userRepository.Insert(user);
            return user;
        }

        public void UpdateUser(int id,DBUser user)
        {
            _userRepository.Update(id,user);
          
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
    }

}
