using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestAPI.Database;
using SharedModel;

namespace RestAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            using (var client = new ItemContext())
            {
                //Create the database file at a path defined in SimpleDataStorage
                client.Database.EnsureCreated();
                //Create the database tables defined in SimpleDataStorage
                client.Database.Migrate();
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ItemContext>();
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new DefaultJsonConverter());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
               // app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();            
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
