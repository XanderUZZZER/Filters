﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Filters
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IFilterDiagnostics, DefaultFilterDiagnostics>();
            //services.AddSingleton<TimeFilter>();
            //services.AddMvc();
            services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();
            services.AddScoped<TimeFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddScoped<DiagnosticsFilter>();
            services.AddMvc().AddMvcOptions(options => {
                //options.Filters.AddService(typeof(ViewResultDiagnostics));
                //options.Filters.AddService(typeof(DiagnosticsFilter));
                options.Filters.Add(new MessageAttribute("This is the Globally-Scoped Filter"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
