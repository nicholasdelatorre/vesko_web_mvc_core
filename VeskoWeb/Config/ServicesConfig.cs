using Microsoft.Extensions.DependencyInjection;
using VeskoWeb.Application.Services;
using VeskoWeb.Domain.Models;
using VeskoWeb.Domain.Services;
using VeskoWeb.Services;

namespace VeskoWeb.Config
{
    public static class ServicesConfig
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddTransient<IGenericService<TeamMember>, TeamMemberAppSvcGeneric>();
            services.AddTransient<IGenericService<Customer>, CustomerAppSvcGeneric>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
        }
    }
}
