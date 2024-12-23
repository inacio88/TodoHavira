using System.Security.Claims;


namespace Todo.Api.Common
{
    public static class ClaimPrincipalExtension
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            var guidString = user.Claims.FirstOrDefault(x => x.Type == "id")?.Value ?? string.Empty;
            return Guid.Parse(guidString);
        }
    }
}