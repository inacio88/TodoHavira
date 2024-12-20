using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Api.Handlers;
using Todo.Core.Handlers;

namespace Todo.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ConfigurationApi.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                            ?? string.Empty;
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
        }
    }
}