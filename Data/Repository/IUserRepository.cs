using Common.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        int AddUser(User user);
        User? AuthUser(CredentialsDTO credentialsDTO);
    }
}
