using CandidateService.Application.Abstract_Services;
using CandidateService.Application.Services;
using CandidateService.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateService, Application.Services.CandidateService>();
            services.AddScoped<ICandidateSkillService, CandidateSkillService>();
            services.AddScoped<ICandidateSkillRepository, CandidateSkillRepository>();
            return services;
        }
    }
}
