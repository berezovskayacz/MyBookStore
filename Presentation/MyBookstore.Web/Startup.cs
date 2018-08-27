using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Core;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Collections.Generic;
using MyBookstore.Models;
using System;
using System.Linq;
using Newtonsoft.Json;
using MyBookstore.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using System.IO;
using NLog;
using NLog.Web;
using Newtonsoft.Json.Converters;
using MyBookstore.Services;
using Microsoft.AspNetCore.Identity;

namespace MyBookstore.Web.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private string _connectionString;

        public Startup(IHostingEnvironment env)
        {
            string settingsFolder = new DirectoryInfo(env.ContentRootPath).Parent.Parent.FullName + "\\Settings\\";


            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(settingsFolder + "appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            _connectionString = Configuration.GetConnectionString("conn");
            env.ConfigureNLog(settingsFolder + "nlog.config");
            LogManager.Configuration.Variables["connectionString"] = _connectionString;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:5000"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });


            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddSession();


            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });



            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter
                {
                    CamelCaseText = false
                });


            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAutoMapper(typeof(Startup));
            services.AddMemoryCache();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("SiteCorsPolicy"));
            });


            var mcInstances = new List<IMapperConfiguration>();
            mcInstances.Add(new EntityMapperConfigs());
            mcInstances.Add(new ModelMapperConfigs());
            mcInstances = mcInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            var configurationActions = new List<Action<IMapperConfigurationExpression>>();
            foreach (var mc in mcInstances)
                configurationActions.Add(mc.GetConfiguration());
            AutoMapperConfiguration.Init(configurationActions);


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_connectionString, b => b.MigrationsAssembly("MyBookstore.Web"));
            });


            services.AddIdentity<ApplicationUser, ApplicationRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();


            services.Configure<MyBookstoreSettings>(Configuration.GetSection("MyBookstoreSettings"));
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IMyBookstoreService, MyBookstoreService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMailingService, MailingService>();
        }

        public void Configure(IApplicationBuilder app, ApplicationDbContext db)
        {
            app.UseSession();
            app.UseCors("SiteCorsPolicy");

           
           
            //env.EnvironmentName = EnvironmentName.Production;
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/error");
            //}

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
