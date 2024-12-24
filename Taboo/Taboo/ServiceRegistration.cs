﻿using Microsoft.AspNetCore.Diagnostics;
using Taboo.Enums;
using Taboo.Exceptions;
using Taboo.ExternalServices.Abstracts;
using Taboo.ExternalServices.Implements;
using Taboo.Services.Abstracts;
using Taboo.Services.Implements;

namespace Taboo;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IWordService, WordService>();
        return services;
    }
    public static IServiceCollection AddCacheService(this IServiceCollection services, IConfiguration _conf, CacheTypes type = CacheTypes.Redis)
    {
        if (type == CacheTypes.Redis)
        {
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = _conf.GetConnectionString("Redis");
                opt.InstanceName = "Tabu_";
            });
            services.AddScoped<ICacheService, RedisService>();
        }
        else
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheService, LocalCacheService>();
        }
        return services;
    }

    public static IApplicationBuilder UseTabuExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(handler =>
        {
            handler.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerFeature>();
                Exception exc = feature!.Error;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                if (exc is IBaseException ibe)
                {
                    context.Response.StatusCode = ibe.StatusCode;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = ibe.StatusCode,
                        Message = ibe.ErrorMessage
                    });
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Xeta bash verdi!"
                    });
                }
            });
        });
        return app;
    }
}

