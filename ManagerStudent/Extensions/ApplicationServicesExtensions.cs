using ManagerStudent.Core.Entities;
using ManagerStudent.Core.Interfaces;
using ManagerStudent.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ManagerStudent.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddInterfacesRepository(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();

            return services;
        }
    }
}
