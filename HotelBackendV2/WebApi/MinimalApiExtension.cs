
using Microsoft.EntityFrameworkCore;

public static class MinimalApiExtension
{
    public static void ConfigureMinimalApi(this WebApplicationBuilder builder, IServiceCollection services)
    {
        var cs = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<HotelDbContext>(options => options.UseNpgsql(cs));
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(MinimalApiExtension).Assembly);
        });

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();

    }
}


