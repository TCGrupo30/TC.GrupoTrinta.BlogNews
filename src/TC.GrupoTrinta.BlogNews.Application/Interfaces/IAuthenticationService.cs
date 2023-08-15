namespace TC.GrupoTrinta.BlogNews.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> ExistsUserAsync(string username);
        Task<string?> AuthenticationAsync(string userName, string password);
    }
}
