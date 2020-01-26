using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Theta.Customers.API.Configuration;

namespace Theta.Customers.API
{
    public class Startup
    {
        public IConfiguration Config { get; }

        public Startup(IConfiguration config)
        {
            this.Config = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc();

            services.Configure<CustomerSettings>(Config.GetSection("CustomerSettings"));
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseMvc();
        }
    }
}
