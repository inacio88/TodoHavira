using Todo.Core.Entities;

namespace Todo.Core.Services
{
    public interface ITokenService
    {
        public string Generate(UserAuthenticated data);
    }
}