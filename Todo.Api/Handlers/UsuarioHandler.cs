using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Api.Services;
using Todo.Core.Entities;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;
using Todo.Core.ValueObjects;

namespace Todo.Api.Handlers
{
    public class UsuarioHandler(AppDbContext context) : IUsuarioHandler
    {
        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
        {
            return await context.Users.AsNoTracking().AnyAsync(x => x.Email.Address == email, cancellationToken);
        }

        public async Task SaveAsync(User user, CancellationToken cancellationToken)
        {
            await context.Users.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await context.Users
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Email.Address == email, cancellationToken);
        }

        public async Task<Response<UserAuthenticated?>> CriarAsync(CriarUsuarioRequest request, CancellationToken cancellationToken)
        {


            #region 2 - gerar os objetos
            Email email;
            Password password;
            User user;
            try
            {
                email = new Email(request.Email);
                password = new Password(request.Password);
                user = new User(request.Name, email, password);
            }
            catch (Exception e)
            {
                return new Response<UserAuthenticated?>(null, 400, e.Message);
            }
            #endregion

            #region 3 - Verifica se o usuário existe no banco
            try
            {
                var exists = await AnyAsync(request.Email, cancellationToken);
                if (exists)
                    return new Response<UserAuthenticated?>(null, 400, "Este email já está em uso");
            }
            catch
            {
                return new Response<UserAuthenticated?>(null,  500, "Não foi possível verificar email cadastrado");
            }
            #endregion

            #region 4 - persisitir no banco
            try
            {
                await SaveAsync(user, cancellationToken);
            }
            catch
            {
                return new Response<UserAuthenticated?>(null, 500, "Falha ao persisitir dados");
            }
            #endregion
            var token = TokenService.Generate(user);
            var userAuthenticated = new UserAuthenticated(user.Id, user.Name, user.Email, token);
            return new Response<UserAuthenticated?>(userAuthenticated, 200, "Usuario criado com sucesso!");
        }
    }
}