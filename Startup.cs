using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication2.Domain;
using WebApplication2.Domain.Repositories;
using WebApplication2.Domain.Services;
using WebApplication2.Domain.UnitOfWork;
using WebApplication2.services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApplication2.Security.Token;

namespace WebApplication2
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
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped(typeof(IGenericService<>), (typeof(GenericService<>)));

            services.AddScoped<IAuthenticationService, AuthenticationService>();


            services.AddScoped<ITokenHandler, TokenHandler>();

            //--------------------------------------------------------------------------

            services.AddScoped<IUserService,UserServices>();

            services.AddScoped<IUserRepository, UserRepository>();
            //-------------------------------------------------------------------------
            //services.AddScoped<IProductService, ProductServices>();

            //services.AddScoped<IProductRepository, ProductRepository>();
            //--------------------------------------------------------------------------
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors(opts => 
            {
                opts.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                
                });
                opts.AddPolicy("zudunyaPolicy", builder =>
                {
                    // artýk api uygulamasý sadece aþþagýdaki orjinden gelen tüm isteklere cevap verecek
                    //ilerde baþka orjinlerde eklene bilir
                    builder.WithOrigins("http://wwww.zudunya.com").AllowAnyHeader().AllowAnyMethod();

                });
            
            });

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtbeareroptions=> 
            {
                jwtbeareroptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                    
                };

            });





            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<UdemyApiWithTokenDBContext>(options => 
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"]);
            
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMvc();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseCors("zudunyaPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
