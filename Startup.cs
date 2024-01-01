using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<OracleDbContext>(options =>
            options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<BookService>();

        services.AddControllers();
    }

    // public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    // {
    //     if (env.IsDevelopment())
    //     {
    //         app.UseDeveloperExceptionPage();
    //     }

    //     app.UseRouting();

    //     app.UseEndpoints(endpoints =>
    //     {
    //         endpoints.MapControllers();
    //     });
    // }
    public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<OracleDbContext>(options =>
        options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<BookService>();
    services.AddScoped<CategoryService>(); // Pindahkan baris ini ke dalam metode ConfigureServices

    services.AddControllers();
}

}
// services.AddScoped<CategoryService>();
