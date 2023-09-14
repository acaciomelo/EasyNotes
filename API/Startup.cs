using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// Import necessary namespaces for JWT authentication

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

        // Register services
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<INoteService, NoteService>();

        // Add database connection using Dapper
        services.AddTransient<IDbConnection>(b => 
            new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));

        // Add JWT authentication based on the JwtSettings section of the appsettings file
        // ... JWT config goes here ...

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        // Add middleware for JWT authentication
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
