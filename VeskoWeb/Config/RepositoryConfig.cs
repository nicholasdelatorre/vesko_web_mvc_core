using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeskoWeb.DataBase.Context;

namespace VeskoWeb.Config
{
    public static class RepositoryConfig
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("VeskoDB");
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connString));
        }
    }
}
