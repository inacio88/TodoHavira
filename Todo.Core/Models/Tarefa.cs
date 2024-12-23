namespace Todo.Core.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set;}
        public DateTime? DataConclusao { get; set; }
        public Guid IdUsuario { get; set; }

    }
}