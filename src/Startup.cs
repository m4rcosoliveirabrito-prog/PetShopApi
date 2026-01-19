using Microsoft.EntityFrameworkCore;
using PetShop.Infra;
using PetshopApi.Infra;

namespace PetShop;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<PetDbContext>(options =>
        {
            var cs = Configuration.GetConnectionString("SqlServer");
            options.UseSqlServer(cs);
        });

        services.AddScoped<PetRepository>();
        services.AddScoped<VacinaRepository>();
        services.AddScoped<CartaoVacinaRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}