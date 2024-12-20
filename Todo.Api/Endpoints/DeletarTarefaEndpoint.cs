using Todo.Core.Models;
using Todo.Api.Common;
using Todo.Core.Handlers;
using Todo.Core.Requests;
using Todo.Core.Responses;
namespace Todo.Api.Endpoints
{
    public class DeletarTarefaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
                .WithName("Tarefa: Delete")
                .WithSummary("Deleta uma tarefa")
                .WithDescription("Deleta uma tarefa")
                .WithOrder(5)
                .Produces<Response<Tarefa?>>()
                ;

        private static async Task<IResult> HandleAsync( ITarefaHandler handler, long id)
        {
            var request = new DeletarTarefaRequest {Id = id, IdUsuario = 1};
            var result = await handler.DeletarAsync(request);

            if (result.IsSuccess)
                return TypedResults.Ok(result);


            return TypedResults.BadRequest(result);
        }
    }
}