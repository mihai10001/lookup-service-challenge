using Amach.Domain.Interfaces;
using Amach.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amach.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddTransient<ILookupService, LookupService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}