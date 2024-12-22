namespace Todo.Core.Entities
{
    public class UserAuthenticated
    {
        public UserAuthenticated(Guid id, string name, string email, string token)
        {
            Id = id;
            Name = name;
            Email = email;
            Token = token;
        }

        public string Token { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}