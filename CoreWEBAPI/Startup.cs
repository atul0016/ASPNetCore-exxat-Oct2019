using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CoreWEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using CoreWEBAPI.Services;

namespace CoreWEBAPI
{
    public class Startup
    {
        /// <summary>
        /// IConfiguration interface is injected by WebHost class 
        /// to read all application Configurations from appSettings.json file
        /// e.g. Database connection string, security info, logging, etc. 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This will provide D.I. contianer for all 'repositories', database objects, security
        // for the cuurent application using IServiceCollection ingterface
        // The DI must manage the Object registration with its lifecycle, Singleton()
        // scopped() and Transient()
        public void ConfigureServices(IServiceCollection services)
        {
            // register the DbContext in the DI Container and 
            // pass the connectionstring to it
            // thois will be registered as scoped obnject in DI
            services.AddDbContext<StudentDbContext>(
                  options => options.UseSqlServer(
                      Configuration.GetConnectionString("AppConnection"))
                );

            // register the StudentService in DI Container as scoped
            services.AddScoped<IService<Student, int>, StudentService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The  method for Http Request Execution
        // Handle Http Request
        // Execute all 'Middleware (?)' using IApplicationBuilder (?) interface
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
