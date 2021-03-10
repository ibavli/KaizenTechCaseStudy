using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaizenTechCaseStudy.Dal.Abstract.BlogService;
using KaizenTechCaseStudy.Dal.Abstract.UserService;
using KaizenTechCaseStudy.Dal.Concrete.BlogService;
using KaizenTechCaseStudy.Dal.Concrete.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KaizenTechCaseStudy.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Dependency Injection

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();

            #endregion
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
