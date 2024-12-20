using Microsoft.EntityFrameworkCore;
using Todo.Api.Data;
using Todo.Core.Handlers;
using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;

namespace Todo.Api.Handlers
{
    public class TarefaHandler(AppDbContext context) : ITarefaHandler
    {
        public async Task<Response<Tarefa?>> CriarAsync(CriarTarefaRequest request)
        {
            try
            {
                var tarefa = new Tarefa
                {
                    Titulo = request.Titulo,
                    Descricao = request.Descricao,
                    DataCriacao = DateTime.Now,
                    DataConclusao = request.DataConclusao,
                    IdUsuario = request.IdUsuario
                };

                await context.Tarefas.AddAsync(tarefa);
                await context.SaveChangesAsync();

                return new Response<Tarefa?>(tarefa, 201, "tarefa criada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Response<Tarefa?>(null, 500, "Não foi possível criar a tarefa");

            }
        }

        public async Task<Response<Tarefa?>> EditarAsync(EditarTarefaRequest request)
        {
            try
            {
                var tarefa = await context.Tarefas.FirstOrDefaultAsync(x => x.Id == request.Id && x.IdUsuario == request.IdUsuario);

                if (tarefa is null)
                    return new Response<Tarefa?>(null, 404, "Tarefa não encontrada");

                tarefa.Titulo = request.Titulo;
                tarefa.Descricao = request.Descricao;
                tarefa.DataConclusao = request.DataConclusao;


                context.Tarefas.Update(tarefa);
                await context.SaveChangesAsync();

                return new Response<Tarefa?>(tarefa, message: "Tarefa atualizada com sucesso");
            }
            catch
            {

                return new Response<Tarefa?>(null, 500, "Não foi possível alterar a tarefa");
            }
        }

        public Task<Response<Tarefa?>> DeletarAsync(DeletarTarefaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Tarefa?>> ObterPorIdAsync(ObterPorIdTarefaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Tarefa>>> ObterTodasAsync(ObterTodasTarefasRequest request)
        {
            throw new NotImplementedException();
        }
    }
}