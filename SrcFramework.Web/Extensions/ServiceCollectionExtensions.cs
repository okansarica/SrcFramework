using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SrcFramework.Security.JsonWebToken;

namespace System
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthenticationCustom(this IServiceCollection services, bool isDevelopment)
        {
            var jsonWebToken = services.BuildServiceProvider().GetService<IJsonWebToken>();

            jsonWebToken.IsDevelopment = isDevelopment;

            void JwtBearer(JwtBearerOptions jwtBearer)
            {
                jwtBearer.RequireHttpsMetadata = false;
                jwtBearer.SaveToken = true;
                jwtBearer.TokenValidationParameters = jsonWebToken.TokenValidationParameters;

                jwtBearer.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        using (var scope = context.HttpContext.RequestServices.CreateScope())
                        {
                            // var sessionValidator = scope.ServiceProvider.GetRequiredService<ISingleSessionValidator>();
                            // await sessionValidator.ValidateSession(context);
                        }
                    },
                    
                    OnChallenge = async (context) =>
                    {
                        using (var scope = context.HttpContext.RequestServices.CreateScope())
                        {
                            // var sessionValidator = scope.ServiceProvider.GetRequiredService<ISingleSessionValidator>();
                            // await sessionValidator.HandleFailChallenge(context);
                        }
                    },

                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/notification"))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        // public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
        // {
        //     DependencyInjector.RegisterServices(services);
        //     DependencyInjector.AddDbContext<DesignAutomatorContext>(configuration.GetConnectionString("DefaultConnection"));
        // }
        //
        // public static void AddSpaStaticFilesCustom(this IServiceCollection services)
        // {
        //     services.AddSpaStaticFiles(spa => spa.RootPath = "ClientApp/dist");
        // }
        //
        // public static void AddMvcCustom(this IServiceCollection services)
        // {
        //     void Mvc(MvcOptions mvc)
        //     {
        //         var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        //         mvc.Filters.Add(new AuthorizeFilter(policy));
        //
        //     }
        //
        //     void Json(MvcJsonOptions json)
        //     {
        //         json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //         json.SerializerSettings.NullValueHandling = NullValueHandling.Include;
        //     }
        //
        //     services.AddMvc(Mvc).AddJsonOptions(Json)
        //         .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        //         .AddApplicationPart(Assembly.Load(new AssemblyName("Web.CommonTypes")));
        // }
    }
    
}