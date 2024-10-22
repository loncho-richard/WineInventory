using Common.Models;
using Data.Entities;

namespace Services
{
    public interface IUserServices
    {
        int AddUser(CreateUserDTO createUserDTO);
        User? AuthUser(CredentialsDTO credentialsDTO);
    }
}
