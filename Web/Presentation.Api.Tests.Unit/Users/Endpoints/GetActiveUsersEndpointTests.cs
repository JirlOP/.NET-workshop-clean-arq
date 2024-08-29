using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Net.Http.Json;
using UCR.ECCI.IS.ExampleProject.Application.Users.Services;
using UCR.ECCI.IS.ExampleProject.Domain.Users.Entities;
using UCR.ECCI.IS.ExampleProject.Domain.Users.ValueObjects;
using UCR.ECCI.IS.ExampleProject.Presentation.Api.Users.Responses;

namespace UCR.ECCI.IS.ExampleProject.Presentation.Api.Tests.Unit.Users.Endpoints;

public class GetActiveUsersEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{

    private readonly WebApplicationFactory<Program> _webApplicationFactory;

    public GetActiveUsersEndpointTests()
    {
        _webApplicationFactory = new WebApplicationFactory<Program>();
    }

    [Fact]
    public async Task GetActiveUsers_WhenNoActiveUsers_ReturnsEmptyList()
    {
        // Arrange
        Mock<IUserService> userServiceMock = new();
        userServiceMock
            .Setup(service => service.GetActiveUsersAsync())
            .ReturnsAsync(Array.Empty<User>());

        // set web services
        var client = _webApplicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient(_ => userServiceMock.Object);
                });
            })
            .CreateClient();


        // Act
        var response = await client.GetFromJsonAsync<GetActiveUsersResponse>("/active-users");

        // Assert
        response.Should().NotBeNull(
            because: "the active-users endpoint should never return null");
        response!.ActiveUsers.Should().BeEmpty(
            because: "the active—users endpoint should return an empty list when there are no active users");
    }

    [Fact]
    public async Task GetActiveUsers_WhenActiveUsers_ReturnsUsersList()
    {
        // Arrange
        User[] activeUsers = [
            new User(
                userId: Guid.Parse("9d190ba3-1ec6-4091-9781-d7f71a15b76a"),
                name: Name.Create("First"),
                lastName: Name.Create("Last"),
                email: Email.Create("first.last@email.com"),
                isActive: true),
            new User(
                userId: Guid.Parse("e18cd860-e44e-461d-a0b4-127696944ade"),
                name: Name.Create("First2"),
                lastName: Name.Create("Last2"),
                email: Email.Create("first.last2@email.com"),
                isActive: true)
            ];

        // mock user service
        Mock<IUserService> userServiceMock = new();
        userServiceMock
            .Setup(service => service.GetActiveUsersAsync())
            .ReturnsAsync(activeUsers);
                
        // set web services
        var client = _webApplicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient(_ => userServiceMock.Object);
                });
            })
            .CreateClient();

        // Act
        var response = await client.GetFromJsonAsync<GetActiveUsersResponse>("/active-users");

        // Assert
        response.Should().NotBeNull(
            because: "the active-users endpoint should never return null");
        response!.ActiveUsers.Should().HaveCount(2,
            because: "the active—users endpoint should return the list of active users");
    }

}
