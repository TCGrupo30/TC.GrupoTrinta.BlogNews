using Microsoft.EntityFrameworkCore;
using TC.GrupoTrinta.BlogNews.Domain.Entity;
using TC.GrupoTrinta.BlogNews.Infra.Data.EF.Configurations;

namespace TC.GrupoTrinta.BlogNews.Infra.Data.EF;
public class BlogNewsDbContext : DbContext
{
    public DbSet<News> News => Set<News>();

    public BlogNewsDbContext(
        DbContextOptions<BlogNewsDbContext> options
    ) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new NewsConfiguration());
    }
}
