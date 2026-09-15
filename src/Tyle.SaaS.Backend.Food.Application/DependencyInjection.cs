using Microsoft.Extensions.DependencyInjection;

namespace Tyle.SaaS.Backend.Food.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddFoodApplication(this IServiceCollection services)
    {
        return services;
    }
}
