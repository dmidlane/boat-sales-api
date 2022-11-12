
namespace BoatSalesApi.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddBoatSalesServices(this IServiceCollection services)
    {
        services.AddSingleton<IBoatService, BoatService>();
        
        return services;        
    }

}