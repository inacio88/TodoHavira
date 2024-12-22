
using Todo.Core.Entities;
using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;

namespace Todo.Core.Handlers
{
    public interface IUsuarioHandler
    {
        public Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
        public Task SaveAsync(User user, CancellationToken cancellationToken);
        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        public Task<Response<UserAuthenticated?>> CriarAsync(CriarUsuarioRequest request, CancellationToken cancellationToken);
    }
}