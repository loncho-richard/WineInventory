using Data.Entities;
using Common.Models;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WineInventoryContext _context;
        public UserRepository(WineInventoryContext winesInventoryContext)
        {
            _context = winesInventoryContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public int AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return _context.Users.Max(u => u.Id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public User? AuthUser(CredentialsDTO credentialsDTO)
        {
            return _context.Users.FirstOrDefault(u => u.Username == credentialsDTO.Username && u.Password == credentialsDTO.Password);
        }
    }
}
