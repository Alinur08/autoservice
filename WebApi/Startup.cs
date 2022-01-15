using AutoMapper;
using Business.Mappers.AutoMapper;
using Core.Configurations.CloudinaryConfiguration.Entities.Concrete;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using Core1.DependencyResolvers;
using Core1.Extentions;
using Core1.Utilities.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace WebApi
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
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:4200"));
            });
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg=>cfg.AddProfile(new AutoMapperProfiles()));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = tokenOptions.Audience,
                        ValidIssuer = tokenOptions.Issuer,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddDependencyResolvers(new ICoreModule[] {
               new CoreModule()
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
