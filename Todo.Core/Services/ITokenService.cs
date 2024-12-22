using Todo.Core.Responses;

namespace Todo.Core.Services
{
    public interface ITokenService
    {
        public string Generate(ResponseAuthenticatedUser data);
    }
}