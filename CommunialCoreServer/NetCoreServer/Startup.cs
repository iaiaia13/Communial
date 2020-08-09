using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NetCoreData;
using NetCoreData.Repos;
using NetCoreData.ReposInterface;
using NetCoreServer.Services;
using System.Text;

namespace NetCoreServer
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();

            services.AddCors(o => o.AddPolicy("ReactPolicy", builder =>
            {
                // builder.AllowAnyOrigin()  --> Can Not used

                builder.SetIsOriginAllowed(_ => true)
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            services.AddControllers();

            services.AddDbContext<DataContext>(options => options.UseMySQL(Configuration["ConnectionStrings:DefaultConnection"]));

            services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];

                /*
                 * Run this if use rows upper
                 *
                 dotnet user-secrets init
                 dotnet user-secrets set "Authentication:Google:ClientId" <Configuration.GetValue<string>("ClientId")>
                 dotnet user-secrets set "Authentication:Google:ClientSecret" <Configuration.GetValue<string>("ClientSecret")>
                 */

                options.SaveTokens = true;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecretKey"))
                    )
                };
            });

            services.AddSingleton<IAuthService>(
                new AuthService(
                    Configuration.GetValue<string>("JWTSecretKey"),
                    Configuration.GetValue<int>("JWTLifespan")
                )
            );
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

            // With endpoint routing, the CORS middleware must be configured to execute between the calls to UseRouting and UseEndpoints.
            app.UseCors("ReactPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}