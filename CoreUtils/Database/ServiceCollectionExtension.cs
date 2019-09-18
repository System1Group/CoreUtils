namespace System1Group.Lib.CoreUtils.Database
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreUtilEfRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IViewRepository<>), typeof(EfViewRepository<>));

            return services;
        }
    }
}
