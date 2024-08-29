using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UCR.ECCI.IS.ExampleProject.Unity.Application.Users
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetActiveUsersAsync();
    }
}
