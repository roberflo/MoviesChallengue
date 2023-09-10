using Challenge.Movies.Api.Utility;
using Challenge.Movies.Application;
using Challenge.Movies.Identity;
using Challenge.Movies.Persistence;
using Challengue.Movies.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Challenge.Movies.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddCors(options => options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            
            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge Movies API");
                
            });

            application.UseHttpsRedirection();
            application.UseRouting();
            application.UseCors("Open");
            application.UseAuthentication();
            application.UseAuthorization();
            application.MapControllers();
            
            return application;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
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

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Challenge Movies API",

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }
        public static async Task ResetDatabaseAsync(this WebApplication app) 
        {
         using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<ChallengeDbContext>();
                if (context != null) 
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }

                var contextIdentity = scope.ServiceProvider.GetService<IdentityDbContext>();
                if (contextIdentity != null)
                {
                    await contextIdentity.Database.EnsureDeletedAsync();
                    await contextIdentity.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                //add logging in the future
                throw;
            }
        }
    }
}
