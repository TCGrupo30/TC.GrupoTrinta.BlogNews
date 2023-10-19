using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TC.GrupoTrinta.BlogNews.Domain.Entity;

namespace TC.GrupoTrinta.BlogNews.Infra.Data.EF.Configurations;
internal class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.HasKey(news => news.Id);
        builder.Property(news => news.Title).HasMaxLength(100).HasColumnType("varchar");
        builder.Property(news => news.Content).HasMaxLength(500).HasColumnType("varchar");
        builder.Property(news => news.Author).HasMaxLength(50).HasColumnType("varchar");
        builder.Property(news => news.PublicationDate).HasColumnType("Datetime");
        builder.Property(news => news.CreateAt).HasColumnType("Datetime");
    }
}
