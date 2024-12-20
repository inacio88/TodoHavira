using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Requests
{
    public class EditarTarefaRequest: Request
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Título inválido")]
        [MaxLength(80, ErrorMessage = "O título deve ter no máximo 80 caracteres")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Descrição inválido")]
        [MaxLength(255, ErrorMessage = "A descrição deve ter no máximo 255 caracteres")]
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataConclusao { get; set; }
    }
}