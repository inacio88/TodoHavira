namespace Todo.Core.Responses
{
    public class ResponseAuthenticatedUser
    {
        public string Token { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}