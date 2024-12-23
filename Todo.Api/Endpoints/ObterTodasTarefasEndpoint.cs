using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Common;
using Todo.Core;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;
namespace Todo.Api.Endpoints
{
    public class ObterTodasTarefasEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                    .WithName("Tarefa: obter uma lista")
                    .WithSummary("Obtém uma lista de tarefas")
                    .WithDescription("Obtém lista de tarefas")
                    .WithOrder(4)
                    .Produces<PagedResponse<List<Tarefa>?>>()
                    ;

        private static async Task<IResult> HandleAsync(ITarefaHandler handler, ClaimsPrincipal user, [FromQuery] int pageNumber = Configuration.DefaultPageNumber, [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var userGuid = user.Id();
            var request = new ObterTodasTarefasRequest {IdUsuario = userGuid, PageNumber = pageNumber, PageSize = pageSize};

            var result = await handler.ObterTodasAsync(request);

            if (result.IsSuccess)
                return TypedResults.Ok(result);


            return TypedResults.BadRequest(result);
        }
    }
}