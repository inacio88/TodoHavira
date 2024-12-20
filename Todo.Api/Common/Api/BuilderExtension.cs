using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;

namespace Todo.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
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
                options.UseSqlServer(Configuration.ConnectionString);
            });

        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            
        }
    }
}