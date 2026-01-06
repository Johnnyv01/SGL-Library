namespace WebApplication1
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services)
        {
            services.AddScoped<Interfaces.IAutorInterface, Services.Autor.AutorService>();
            return services;
        }
    }
}
