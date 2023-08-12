using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TC.GrupoTrinta.BlogNews.Domain.Entity;

namespace TC.GrupoTrinta.BlogNews.Infra.Data.EF.Configurations;
internal class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.HasKey(news => news.Id);
    }
}
