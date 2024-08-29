$apiClientLocations = @("../Web/Infraestructure.ApiClient/Client", "../UnityExampleProject/Assets/Scripts/Infraestructure/Client")

$apiClientLocations | ForEach-Object {
    & kiota generate -l CSharp -c ApiClientKiota -n UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient -d https://localhost:7245/swagger/v1/swagger.json -o $_ --clean-output
}