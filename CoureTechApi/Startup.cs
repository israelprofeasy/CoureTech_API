using CoureTechApi.DataAccess;
using CoureTechApi.DataServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoureTechApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(options => options.SwaggerDoc(
                "v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "CoureTech Api Assessment",
                    Description = "An API GET method type that detects country code from phone number and display country details"
                }));
            services.AddTransient<SeederClass>();
            services.AddScoped<IInMemoryRepository, InMemoryRepository>();
            services.AddScoped<IPhoneNumberDetailService, PhoneNumberDetailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeederClass seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            seed.SeedMe().Wait();
            app.UseSwagger();
            app.UseSwaggerUI(option => option.SwaggerEndpoint("/swagger/v1/swagger.json", "CoureTech Api Assessment"));
        }
    }
}
