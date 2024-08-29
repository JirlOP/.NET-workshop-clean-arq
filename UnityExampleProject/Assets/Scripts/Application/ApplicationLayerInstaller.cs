using UCR.ECCI.IS.ExampleProject.Unity.Application.Users;
using Zenject;

public class ApplicationLayerInstaller : Installer<ApplicationLayerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IUserService>()
            .To<UserService>()
            .AsTransient();
    }
}