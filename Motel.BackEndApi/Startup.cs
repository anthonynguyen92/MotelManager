using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Motel.Application.Category.BillPayment;
using Motel.Application.Category.CustomerRent;
using Motel.Application.Category.CustomerRent.Dtos;
using Motel.Application.Category.FamilyGroups;
using Motel.Application.Category.InfoRent;
using Motel.Application.Category.RoomMotel;
using Motel.Application.Category.User;
using Motel.EntityDb.EF;
using Motel.EntityDb.Entities;
using Motel.Utilities.Contains;
using Motel.Utilities.Exceptions;
using Motel.Utilities.Helper;
using Motel.ViewModel.System.User;
using System.Collections.Generic;
using System.Text;

namespace Motel.BackEndApi
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
            services.AddControllers();

            services.AddDbContext<MotelDbContext>(option => option
                .UseSqlServer(Configuration
                .GetConnectionString(SystemContains.MainConnectionString)));

            services.AddIdentity<AppUser, AppRoles>()
                .AddEntityFrameworkStores<MotelDbContext>()
                .AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "V1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            #region ? Oauth2
            //add Oauth2
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetValue<string>("Tokens:Issuer"),
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetValue<string>("Tokens:Issuer"),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
            });
            #endregion

            // delcare DI
            services.AddTransient<IPublicBillPayment, PublicBillPayment>();
            services.AddTransient<IManageBillPayment, ManageBillPayment>();
            services.AddTransient<IManageCustomer, ManageCustomer>();
            services.AddTransient<IManageRoomMotel, ManageRoomMotel>();
            services.AddTransient<IManageFamily, ManageFamily>();
            services.AddTransient<IManageRoomMotel, ManageRoomMotel>();
            services.AddTransient<IManageRent, ManageRent>();

            // Declare Login
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRoles>, RoleManager<AppRoles>>();
            services.AddTransient<IValidatorInterceptor, MyDefaultInterceptor>();
            //services.AddMvcCore().AddFluentValidation();

            // DC
            services.AddHttpClient<ISelfHttpClient, SelfHttpClient>();

            //setting
            services.Configure<CustomerSettings>(Configuration.GetSection("Customers"));

            // DC new options
            //services.AddScoped<ICustomerReponsitory, CustomerCacheReponsitory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
           

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

            loggerFactory.AddFile("Log/log.txt");
            app.UseMiddleware<ExceptionsHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
