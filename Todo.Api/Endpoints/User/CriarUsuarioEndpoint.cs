using System.ComponentModel.DataAnnotations;
using Todo.Api.Common;
using Todo.Api.Services;
using Todo.Core.Handlers;
using Todo.Core.Requests;
using Todo.Core.Responses;

namespace Todo.Api.Endpoints.User
{
    public class CriarUsuarioEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                    .WithName("Usuario: ")
                    .WithSummary("Usuario")
                    .WithDescription("usuário")
                    .WithOrder(1)
                    .Produces<Response<ResponseAuthenticatedUser?>>()
                    ;

        private static async Task<IResult> HandleAsync(ITarefaHandler handler, CriarUsuarioRequest request)
        {
            System.Console.WriteLine(request.Email);
            System.Console.WriteLine(request.Password);
            var validationContext = new ValidationContext(request);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(request, validationContext, validationResults, true);
            if (!isValid)
                return Results.BadRequest(validationResults);

            // request.IdUsuario = 1;
            // var result = await handler.CriarAsync(request);

            // if (result.IsSuccess)
            //     return TypedResults.Created($"/{result.Data?.Id}", result);


            // return TypedResults.BadRequest(result);
            var authenticatedUser = new ResponseAuthenticatedUser();
            authenticatedUser.Email = request.Email;
            authenticatedUser.Password = request.Password;
            authenticatedUser.Token = TokenService.Generate(authenticatedUser);

            return Results.Ok(authenticatedUser);
        }
    }
}