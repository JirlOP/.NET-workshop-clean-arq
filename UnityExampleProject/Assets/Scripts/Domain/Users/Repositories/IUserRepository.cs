using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Communicate with Infrastructure layer to get all active users
        /// Implementation of IUserService .GetActiveUsersAsync contract
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetActiveUsersAsync();
    }
}
