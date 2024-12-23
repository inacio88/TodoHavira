using System.Security.Claims;
using Todo.Api.Common;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;
namespace Todo.Api.Endpoints
{
    public class ObterPorIdEndpoint: IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                    .WithName("Tarefa: obter")
                    .WithSummary("Obtém uma tarefa")
                    .WithDescription("Obtém uma tarefa")
                    .WithOrder(3)
                    .Produces<Response<Tarefa?>>()
                    ;

        private static async Task<IResult> HandleAsync(ITarefaHandler handler, ClaimsPrincipal user, int id)
        {
            var userGuid = user.Id();
            
            var request = new ObterPorIdTarefaRequest {Id = id, IdUsuario = userGuid};
            var result = await handler.ObterPorIdAsync(request);

            if (result.IsSuccess)
                return TypedResults.Ok(result);


            return TypedResults.BadRequest(result);
        }
    }
}