using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MISA.CukCuk.ApplicationCore;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.ApplicationCore.Services;
using MISA.CukCuk.Common.Other;
using MISA.CukCuk.Infrastructure;
using MISA.CukCuk.Infrastructure.Interfaces;
using MISA.CukCuk.Infrastructure.Repositories;
using MySql.Data.MySqlClient;
using System.Data;

namespace MISA.CukCuk.Api
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
            string ConnectionString = Configuration.GetConnectionString(Common.Properties.Resources.MariaDbConnectionString);
            services.AddControllers();
            // Chỉ định DBConnection cho data layer
            services.AddTransient<IDbConnection>((connection) => new MySqlConnection(ConnectionString));
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var errMsg = new ErrMsg();
                errMsg.DevMsg.Add(exception.Message);
                errMsg.UserMsg.Add(Common.Properties.Resources.ExceptionNotification);
                await context.Response.WriteAsJsonAsync(errMsg);
            }));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
