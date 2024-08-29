using ECCI.UCR.IS.ExampleProject.Unity.Domain.Users.Repositories;
using ECCI.UCR.IS.ExampleProject.Unity.Infraestructure.Users.Repositories;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient;
using Zenject;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Core.EventSystem;
using ECCI.UCR.IS.ExampleProject.Unity.Infraestructure.Core.EventSystem;
using ECCI.UCR.IS.ExampleProject.Unity.Domain.Assets.Scripts.Domain.Users.Events;
using CandyCoded.env;

namespace ECCI.UCR.IS.ExampleProject.Unity.Infraestructure
{

    /// <summary>
    /// Add the bindings for the infrastructure layer. 
    /// This means add services to the container that are used to interact with the API.
    /// And also register the events that are going to be used in the application that interact with the API as Infrastructure services.
    /// </summary>
    public class InfrastructureLayerInstaller : Installer<InfrastructureLayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAuthenticationProvider>()
                .To<AnonymousAuthenticationProvider>()
                .AsTransient();

            // Get the API base URL from the environment variables.
            // This is managed by the CandyCoded.env package.
            env.TryParseEnvironmentVariable("API_BASE_URL", out string apiBaseUrl);

            Container.Bind<IRequestAdapter>()
                .To<HttpClientRequestAdapter>()
                .AsTransient()
                // Once the HttpClientRequestAdapter is instantiated, set the base URL.
                .OnInstantiated<HttpClientRequestAdapter>((injectContext, requestAdapter) =>
                {
                    requestAdapter.BaseUrl = apiBaseUrl;
                });

            Container.Bind<ApiClientKiota>()
                .ToSelf()
                .AsTransient();

            Container.Bind<IUserRepository>()
                .To<UnityUserRepository>()
                .AsTransient();


            // Install the SignalBusInstaller
            SignalBusInstaller.Install(Container);

            // Register the SignalBusEventChannel as the IEventChannel of Domain.Core.EventSystem
            Container.Bind<IEventChannel>()
                .To<SignalBusEventChannel>()
                .AsSingle(); // a unique channel for the whole application

            RegisterEvents();
        }


        /// <summary>
        /// Register all events that are going to be used in the application.
        /// </summary>
        private void RegisterEvents()
        {
            // Register all events here.
            Container.DeclareSignal<UsersFetchedEvent>();
        }
    }
}