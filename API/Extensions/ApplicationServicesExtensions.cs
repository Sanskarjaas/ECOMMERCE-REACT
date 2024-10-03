using API.Errors;
using Core.Intefaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Controllers;

namespace API.Extensions
{
    public static class ApplicationservicesExtensions
    {
        public static IServiceCollection AddApplicationservices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                //b => b.MigrationsAssembly("Infrastructure"));
                // SqlServerOptions => SqlServerOptions.EnableRetryOnFailure(),
                //options.UseSqlite(config.GetConnectionString("Default"));
            });
            //services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:3000");
                });
            });
            return services;
        }
    }
}
