using System.ComponentModel.DataAnnotations;
using Todo.Api.Common;
using Todo.Core.Entities;
using Todo.Core.Handlers;
using Todo.Core.Requests;
using Todo.Core.Responses;
namespace Todo.Api.Endpoints.User
{
    public class LogarUsuarioEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/login", HandleAsync)
                .WithName("Usuario: logar")
                .WithSummary("logar Usuario")
                .WithDescription("logar usuário")
                .WithOrder(2)
                .Produces<Response<UserAuthenticated?>>()
                ;

        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, LogarUsuarioRequest request)
        {
            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);
            if (!isValid)
                return Results.BadRequest(validationResults);


            var result = await handler.Logar(request, new CancellationToken());

            if (result.IsSuccess)
                return TypedResults.Ok(result);

            return Results.BadRequest();
        }
    }
}