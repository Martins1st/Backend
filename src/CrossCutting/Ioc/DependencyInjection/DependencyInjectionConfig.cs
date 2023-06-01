
using Application.Interfaces.Services;
using Application.Services;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.UnitOfWork;
using Infra.Context;
using Infra.Repositorios;
using Infra.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Utils.Interfaces;
using Utils.Models;

namespace Ioc.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificador, Notificador>();


            return services;
        }
    }
}
