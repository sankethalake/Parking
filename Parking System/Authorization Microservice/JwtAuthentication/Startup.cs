using JwtAuthentication.Database;
using JwtAuthentication.Models;
using JwtAuthentication.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JwtAuthentication.Database.Login;

namespace JwtAuthentication
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

            var key = Configuration.GetValue<string>("TokenKey");
            
            services.AddControllers();
            services.AddDbContext<LoginDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LoginDb")));
            services.AddScoped<IRepository<Login>,LoginManager>();
            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key));
            services.AddSwaggerGen(c =>
            {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Authorization Microservice", Version = "v1" });
            //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
            //    In = ParameterLocation.Header,
            //    Description = "Please Insert Token",
            //    Name = "Authorization",
            //    Type = SecuritySchemeType.Http,
            //    BearerFormat = "JWT",
            //    Scheme = "bearer"
            //});

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference=new OpenApiReference
            //                {
            //                    Type=ReferenceType.SecurityScheme,
            //                    Id="Bearer"
            //                }
            //            },
            //            new string[]{}
            //        }
            //    });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //}).AddJwtBearer(x=>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            //        ValidateIssuer=true,
            //        ValidateAudience=true,
            //        ValidateLifetime=true,

            //        ValidIssuer= "https://localhost:44375",
            //        ValidAudience= "Admin"
            //    };
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authorization"));
            
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
