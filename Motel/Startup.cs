using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Motel.Application.Category.User;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using Motel.Utilities.Contains;
using System;
using System.Text;

namespace Motel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(5);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            var secretket = Encoding.UTF8.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(token =>
                {
                    
                    token.RequireHttpsMetadata = false;
                    token.SaveToken = true;
                    token.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretket),
                        ValidateIssuer = true,

                        ValidIssuer = "http://locallhost:5001",
                        ValidateAudience = true,

                        ValidAudience = "http://localhost:5001",

                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddDbContext<MotelDbContext>(option => option
                .UseSqlServer(Configuration
                .GetConnectionString(SystemContains.MainConnectionString)));

            services.AddIdentity<AppUser, AppRoles>()
                .AddEntityFrameworkStores<MotelDbContext>()
                .AddDefaultTokenProviders();


            // Declare ID
            //services.AddTransient<IPublicBillPayment, PublicBillPayment>();
            //services.AddTransient<IManageBillPayment, ManageBillPayment>();
            //services.AddTransient<IManageCustomer, ManageCustomer>();
            //services.AddTransient<IManageRoomMotel, ManageRoomMotel>();
            //services.AddTransient<IManageFamily, ManageFamily>();
            //services.AddTransient<IManageRoomMotel, ManageRoomMotel>();
            //services.AddTransient<IManageRent, ManageRent>();

            // Declare Login
            services.AddTransient<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddFile("Logs/Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();
            app.Use(async (context, next) =>
            {
                var jwToken = context.Session.GetString("JwToken");
                if (!string.IsNullOrEmpty(jwToken))
                    context.Request.Headers.Add("Authorization", "Bearer" + jwToken);
                await next();
            });

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{Controller=Home}/{action=Index}/{id?}");

                }
            );

        }
    }
}
