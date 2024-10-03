using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;
using Core.Intefaces;
using API.Errors;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationservices(builder.Configuration);
//builder.Services.AddIdentityServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptioMiddleWare>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwaggerDocumentation();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Content")),
    RequestPath = "/Content"
});
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
//var IdentityContext = services.GetRequiredService<AppIdentityDbContext>();
//var userManager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    //await SeedContextSeed.SeedAsync(context);
    // await IdentityContext.Database.MigrateAsync();
    // await AppIdentityDbContextSeed.SeedUserAsync(userManager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during Migration");
}
app.Run();