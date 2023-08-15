using Microsoft.AspNetCore.Identity;

namespace TC.GrupoTrinta.BlogNews.Infra.Identity;

public class ApplicationUser : IdentityUser<long>
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public DateTime? CreateDate { get; set; }
}