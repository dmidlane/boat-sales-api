
namespace BoatSalesApi.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddBoatSalesServices(this IServiceCollection services)
    {
        services.AddScoped<IBoatService, BoatService>();
        
        return services;        
    }

}