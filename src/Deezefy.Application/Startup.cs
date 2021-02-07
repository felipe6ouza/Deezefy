using Deezefy.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Deezefy.Business.Interfaces;
using Deezefy.Data.Repository;

namespace Deezefy.Application
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddDbContext<DeezefyDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly("Deezefy.Data")));

            services.AddScoped<DeezefyDbContext>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            services.AddScoped<IOuvinteRepository, OuvinteRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
