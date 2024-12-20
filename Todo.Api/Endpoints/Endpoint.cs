using Todo.Api.Common;

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


            endpoints.MapGroup("v1/tarefas")
                .WithTags("tarefas")
                .MapEndpoint<CriarTarefaEndpoint>()
                .MapEndpoint<EditarTarefaEndpoint>()
                .MapEndpoint<ObterPorIdEndpoint>()
                .MapEndpoint<ObterTodasTarefasEndpoint>()
                ;
        }



        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }

    }


}