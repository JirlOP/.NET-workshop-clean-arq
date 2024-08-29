using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Repositories;
using UCR.ECCI.IS.ExampleProject.Infraestructure.ApiClient.Users.Dtos;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.ApiClient.Users.Repositories;

/// <summary>
/// Class to get User Repository from the Interface in Backend/Domain
/// Is a mirror of SqlUserRepository but with the difference that this class uses the ApiClient to get the data
/// and SqlUserRepository uses the database to get the data.
/// </summary>
internal class ApiClientUserRepository : IUserRepository
{
    private readonly ApiClientKiota _apiClient;

    public ApiClientUserRepository(ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IEnumerable<User>> GetActiveUsersAsync()
    {
        // Receive the DTOs from the API
        var response = await _apiClient.ActiveUsers.GetAsync();
        /*  CS0266
         * error: Cannot convert from 'System.Collections.Generic.IEnumerable<UCR.ECCI.IS.ExampleProject.Client.Users.Models.User>'(Kiota) 
         * to 'System.Collections.Generic.IEnumerable<UCR.ECCI.IS.ExampleProject.Domain.Users.Entities.User>'(Domain)
         * Kiota don't know about Domain buisness logic of models.
         * So we need to map the Kiota model to the Domain model.
         * This mapping is done in the Infrastructure layer.
        */
        // Solution: Mapping the Kiota model to the Domain model
        var activeUserEntities = response?.ActiveUsers?.Select(UserDtoMapper.ToEntity) 
            ?? throw new NullReferenceException();
        return activeUserEntities;
    }
}
