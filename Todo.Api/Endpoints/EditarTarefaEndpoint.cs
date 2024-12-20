using System.ComponentModel.DataAnnotations;
using Todo.Api.Common;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints
{
    public class EditarTarefaEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
                    .WithName("Tarefa: editar")
                    .WithSummary("Edita uma tarefa")
                    .WithDescription("Edita uma tarefa")
                    .WithOrder(1)
                    .Produces<Response<Tarefa?>>()
                    ;

        private static async Task<IResult> HandleAsync(ITarefaHandler handler, EditarTarefaRequest request, int id)
        {
            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();
            var  isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);
            
            if(!isValid)
                return Results.BadRequest(validationResults);
            
            if (id != request.Id)
                return Results.BadRequest("Id inválido");

            request.IdUsuario = 1;
            var result = await handler.EditarAsync(request);
            
            if (result.IsSuccess)
                return TypedResults.Ok(result);


            return TypedResults.BadRequest(result);
        }
    }
}