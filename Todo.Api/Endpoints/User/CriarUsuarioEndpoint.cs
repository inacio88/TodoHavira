using System.ComponentModel.DataAnnotations;
using Todo.Api.Common;
using Todo.Core.Entities;
using Todo.Core.Handlers;
using Todo.Core.Requests;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.User
{
    public class CriarUsuarioEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                    .WithName("Usuario: criar")
                    .WithSummary("criar Usuario")
                    .WithDescription("aqui cria um usuário")
                    .WithOrder(1)
                    .Produces<Response<UserAuthenticated?>>()
                    ;

        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, CriarUsuarioRequest request)
        {
            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);
            if (!isValid)
                return Results.BadRequest(validationResults);


            var result = await handler.CriarAsync(request, new CancellationToken());

            if (result.IsSuccess)
                return TypedResults.Created($"/{result.Data?.Id}", result);

            return Results.BadRequest();
        }
    }
}