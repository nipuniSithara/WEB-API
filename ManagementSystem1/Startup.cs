using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository;
using Repository.Interfaces;

namespace ManagementSystem1
{
    public class Startup
    {
        private static string _connectionString { get; set; }
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                       .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IStudentRepository>(c => new StudentService(_connectionString));
            services.AddTransient<IBatchRepository>(c => new BatchService(_connectionString));
            services.AddTransient<IFacultyRepository>(c => new FacultyService(_connectionString));
            services.AddTransient<ICourseRepository>(c => new CourseService(_connectionString));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
