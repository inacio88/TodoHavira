namespace Todo.Api.Common
{
    public static class ConfigurationApi
    {
        public static string ConnectionString {get;set;} = string.Empty;
        public static string JwtPrivateKey {get;set;} = string.Empty;
        public static string PasswordSaltKey {get;set;} = string.Empty;
    }
}