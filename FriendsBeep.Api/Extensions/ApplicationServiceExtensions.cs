using FriendsBeep.Business;
using FriendsBeep.Business.Handler;
using FriendsBeep.Business.Interfaces;
using FriendsBeep.Business.Services;
using FriendsBeep.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsBeep.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<IUsersBLL, UsersBLL>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IErrorHandler,ErrorHandler>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Awesome API",
                    Version = "v1"
                });
            });
            return services;
        }
    }
}
