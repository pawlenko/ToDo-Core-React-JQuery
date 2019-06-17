using Microsoft.Extensions.DependencyInjection;
using ToDo.Business.Interface;
using ToDo.Business.Repository;

namespace ToDo.Business
{
    public static class StartupExtension
    {
        public static IServiceCollection ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IToDoElementRepository, ToDoElementRepository>();

            return services;
        }

    }
}
