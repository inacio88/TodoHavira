using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Requests
{
    public class LogarUsuarioRequest
    {
        [Required(ErrorMessage ="Email é obrigatório")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage ="Password é obrigatório")]
        public string Password { get; set; } = string.Empty;
    }
}