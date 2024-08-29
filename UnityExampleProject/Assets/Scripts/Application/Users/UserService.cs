using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UCR.ECCI.IS.ExampleProject.Unity.Application.Users
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return _userRepository.GetActiveUsersAsync();
        }
    }
}
