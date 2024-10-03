using Core.Entities;
using Core.Entities.Identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentityCore<AppUser>(opt =>
            {
                //
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<AppIdentityDbContext>();
            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }
    }
}