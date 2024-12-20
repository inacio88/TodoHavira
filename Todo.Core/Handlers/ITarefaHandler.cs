using Todo.Core.Models;
using Todo.Core.Requests;
using Todo.Core.Responses;

namespace Todo.Core.Handlers
{
    public interface ITarefaHandler
    {
        Task<Response<Tarefa?>> CriarAsync(CriarTarefaRequest request);
        Task<Response<Tarefa?>> EditarAsync(EditarTarefaRequest request);
        Task<Response<Tarefa?>> DeletarAsync(DeletarTarefaRequest request);
        Task<Response<Tarefa?>> ObterPorIdAsync(ObterPorIdTarefaRequest request);
        Task<PagedResponse<List<Tarefa>>> ObterTodasAsync(ObterTodasTarefasRequest request);
    }
}