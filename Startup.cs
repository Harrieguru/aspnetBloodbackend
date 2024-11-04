using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using webAPI.Models;


namespace webAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services like controllers, dependency injection, etc.
            services.AddControllers();

            // Add database context or other services here (if required)
            services.AddDbContext<DonationDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DevConnection")));
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Detailed error pages in development
            }


            app.UseHttpsRedirection(); // Redirect HTTP to HTTPS

            app.UseRouting(); // Adds route matching to the middleware pipeline

            app.UseAuthorization(); // Add authorization middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map incoming requests to controllers
            });
        }
    }
}
