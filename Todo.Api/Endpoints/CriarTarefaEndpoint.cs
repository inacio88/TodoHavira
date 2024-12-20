using System.ComponentModel.DataAnnotations;
using Todo.Api.Common;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints
{
    public class CriarTarefaEndpoint : IEndpoint
    {
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
                .WithName("Categories: Create")
                .WithSummary("Cria uma nova categoria")
                .WithDescription("Cria uma nova categoria")
                .WithOrder(1)
                .Produces<Response<Tarefa?>>()
                ;

        private static async Task<IResult> HandleAsync(ITarefaHandler handler, CriarTarefaRequest request)
        {
            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();
            var  isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);
            if(!isValid)
                return Results.BadRequest(validationResults);

            request.IdUsuario = 1;
            var result = await handler.CriarAsync(request);
            
            if (result.IsSuccess)
                return TypedResults.Created($"/{result.Data?.Id}", result);


            return TypedResults.BadRequest(result);
        }
    }
}