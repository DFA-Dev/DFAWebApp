using DFAWebApp.Domain.Interfaces;
using DFAWebApp.Domain.Models;
using DFAWebApp.Domain.Services;
using DFAWebApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DFAWebApp.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddAuthorization(config =>
            {
                config.AddPolicy(PoliciesModel.Admin, PoliciesModel.AdminPolicy());
                config.AddPolicy(PoliciesModel.User, PoliciesModel.UserPolicy());
            });

            services.AddScoped<IRepositoryWork, RepositoryWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
