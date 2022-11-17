using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartG.CloudinaryService;
using SmartG.Contracts;
using SmartG.EmailService;
using SmartG.Entities.Models;
using SmartG.LoggerService;
using SmartG.Repository;
using SmartG.Service;
using SmartG.Service.Contracts;
using SmartG.Shared.DTOs;

namespace SmartG.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(options =>
           {
               options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("https://smartganyaupfu.com", "http://smartganyaupfu.com", "https://www.smartganyaupfu.com", "http://www.smartganyaupfu.com", "http://localhost:4000", "http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader().WithExposedHeaders("X-Pagination"));
           });
        public static void ConfigureCloudinary(this IServiceCollection services, IConfiguration configuration) => services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManger>();
        public static void ConfigureCloudinaryImageService(this IServiceCollection services)=>services.AddScoped<IImageUploader,ImageService>();

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration cofiguration) =>
         services.AddDbContext<RepositoryContext>(opts =>
         opts.UseSqlServer(cofiguration.GetConnectionString("SGDatabase"))); // add the nuget package

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();

        }

         public static void ConfigureEmailService(this IServiceCollection services) => services.AddScoped<IEmailSender, EmailSender>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();public static void ConfigureEmail(this IServiceCollection services, IConfiguration configuration)
         {
             var emailConfig = configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
             services.AddSingleton(emailConfig);

         }

         //configuring jwt
         //installl Microsoft.AspNetCore.Authentication.JwtBearer  for ths to work.
         public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
         {
             var jwtSettings = configuration.GetSection("JwtSettings");
             var secretKey = Environment.GetEnvironmentVariable("SECRET");
             var secretK = configuration.GetSection("SecretKey").Value;

             services.AddAuthentication(opt =>
             {
                 opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             }).AddJwtBearer(options => {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                     ValidAudience = jwtSettings.GetSection("validAudience").Value,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretK))
                 };
             });
         }
    }
}

