using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using RestWitASP_NET5Udemy.Business.Implementations;
using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Hypermedia.Enricher;
using RestWitASP_NET5Udemy.Hypermedia.Filters;
using RestWitASP_NET5Udemy.Model.Context;
using RestWitASP_NET5Udemy.Repository.Generic;
using Serilog;
using System;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }
        public object MigrateDatabase { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySQLConnection:MySQLConnecionString"];

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));
            services.AddApiVersioning();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());

            services.AddSingleton(filterOptions);

            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc(("v1"),
               new OpenApiInfo
               {
                   Title = "REST API's  from 0 to Azure with ASP.NE Core 5 and Docker",
                   Version = "v1",
                   Description = "API RESTful developed in course 'REST API's  from 0 to Azure with ASP.NE Core 5 and Docker'",
                   Contact = new OpenApiContact
                   {
                       Name = "Paulo Teixeira",
                       Url = new Uri("https://github.com/paulaodti")
                   }
               });
            });

            if (Environment.IsDevelopment())
            {
                MigrarDatabase(connection);
            }

            //Dependency Injection
            services.AddScoped<IPersonBusiness,PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped(typeof (IRepository<>), typeof (Repository<>));
        }

        private void MigrarDatabase(string connection)
        {
            try
            {
                var envolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(envolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<String> { "db/migrations","db/datasets"},
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI( c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API's  from 0 to Azure with ASP.NE Core 5 and Docker");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
