using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Entities;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Repositories;
using ECCI.UCR.IS.ExampleProject.Unity.Infraestructure.Users.Dtos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient;
using UnityEngine;

namespace ECCI.UCR.IS.ExampleProject.Unity.Infraestructure.Users.Repositories
{
    public class UnityUserRepository : IUserRepository
    {
        private readonly ApiClientKiota _apiClient;

        public UnityUserRepository(ApiClientKiota apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            var response = await _apiClient.ActiveUsers.GetAsync();

            var users = response.ActiveUsers.Select(UserDtoMapper.ToEntity);

            return users;
        }
    }
}
