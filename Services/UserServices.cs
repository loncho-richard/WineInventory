using Common.Models;
using Data.Entities;
using Data.Repository;
using System.ComponentModel;

namespace Services
{
    public class UserServices : IUserServices
    {
        public readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddUser(CreateUserDTO createUserDTO)
        {
            if (_userRepository.GetUsers().All(user => user.Username != createUserDTO.UserName))
            {
                try
                {
                    int newUser = _userRepository.AddUser(
                        new User
                        {
                            Username = createUserDTO.UserName,
                            Password = createUserDTO.Password
                        }
                        );
                    return newUser;
                }
                catch(Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public User? AuthUser(CredentialsDTO credentialsDTO)
        {
            return _userRepository.AuthUser(credentialsDTO);
        }
    }
}