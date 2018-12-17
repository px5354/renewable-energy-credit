using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RenewableEnergyCredits
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
            services.AddMvc();

//            services.AddSingleton(restClient =>
//            {
//                var client = new RestClient
//                {
//                    BaseUrl = new Uri("https://develop.api.mantleblockchain.com")
//                };
//                client.AddDefaultHeader("Content-type", "application/json; charset=utf-8");
//                client.AddDefaultHeader("x-api-key", "0NB1tkB0++UE3Qie3MiFur401AJIyD1ZBxoLcqMw9NA=");
//
//                return client;
//            });
            
//            services.AddSingleton(async mantleConfigClient =>
//            {
//                var config = new Configuration
//                {
//                    BasePath = "https://dev.api.mantle.services"
//                };
//                var auth = new AuthenticationApi(config);
//                var userResponse =
//                    await auth.AuthenticationLoginPostAsync(new UserLoginRequest(
//                        "gabriel@mantle.services", "Test1234"));
//                config.AddDefaultHeader("Authorization", userResponse.AccessToken);
//                return config;
//            });

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
