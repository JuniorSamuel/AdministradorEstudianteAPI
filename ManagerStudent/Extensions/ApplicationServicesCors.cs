namespace ManagerStudent.Extensions
{
    public static class ApplicationServicesCors
    {
        public static string NameOfPolicy { get; set; } = "webApp";

        public static IServiceCollection AddManagerCors(this IServiceCollection services)
        {

            services.AddCors(
                opt => opt.AddPolicy(name: NameOfPolicy, policy =>
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

            return services;
        }
    }
}
