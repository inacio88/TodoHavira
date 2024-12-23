using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Api.Data;
using Todo.Api.Handlers;
using Todo.Api.Services;
using Todo.Core;
using Todo.Core.Handlers;
using Todo.Core.Services;

namespace Todo.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ConfigurationApi.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                            ?? throw new Exception("ConnectionString não encontrada");

            ConfigurationApi.JwtPrivateKey = builder.Configuration.GetSection("Secrets").GetValue<string>("JwtPrivateKey")
                                            ?? throw new Exception("JwtPrivateKey não encontrada");

            Configuration.PasswordSaltKey = builder.Configuration.GetSection("Secrets").GetValue<string>("PasswordSaltKey")
                                            ?? throw new Exception("PasswordSaltKey não encontrada");

        }

        public static void AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfigurationApi.JwtPrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddAuthorization();
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(x => x.FullName);
            });
        }


        public static void AddDataContexts(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationApi.ConnectionString);
            });

        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ITarefaHandler, TarefaHandler>();
            builder.Services.AddTransient<IUsuarioHandler, UsuarioHandler>();
            //builder.Services.AddTransient<ITokenService, TokenService>();
        }
    }
}