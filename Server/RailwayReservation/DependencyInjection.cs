using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using AutoMapper;
using MapsterMapper;

namespace RailwayReservation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapping(this IServiceCollection services) {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<MapsterMapper.IMapper, MapsterMapper.Mapper>();
            return services;
        }
    }
}