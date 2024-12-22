namespace Todo.Core.Models
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        // public Email Email { get; private set; } = null!;
        // public Password Password { get; set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; set; } = null!;
    }
}