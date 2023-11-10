using Demo_Fluint_Api.DataAccess;
using Demo_Fluint_Api.Interfaces;
using Demo_Fluint_Api.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Demo_Fluint_Api.Configuration;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllersWithViews()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddScoped<IUserRepository, UserService>();
    }
}
