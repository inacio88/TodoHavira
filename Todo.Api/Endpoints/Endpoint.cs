using Todo.Api.Common;
using Todo.Api.Endpoints.User;

namespace Todo.Api.Endpoints
{
    public static class Endpoint
    {

        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Health check")
                .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("/")
                .WithTags("Health check")
                .MapGet("/conferir", () => new { message = "OK conferir" })
                .RequireAuthorization()
                ;


            endpoints.MapGroup("v1/tarefas")
                .WithTags("tarefas")
                .RequireAuthorization()
                .MapEndpoint<CriarTarefaEndpoint>()
                .MapEndpoint<EditarTarefaEndpoint>()
                .MapEndpoint<ObterPorIdEndpoint>()
                .MapEndpoint<ObterTodasTarefasEndpoint>()
                .MapEndpoint<DeletarTarefaEndpoint>()
                ;

            endpoints.MapGroup("v1/usuarios")
                .WithTags("usuarios")
                .MapEndpoint<CriarUsuarioEndpoint>()
                .MapEndpoint<LogarUsuarioEndpoint>()
                ;
        }



        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }

    }


}