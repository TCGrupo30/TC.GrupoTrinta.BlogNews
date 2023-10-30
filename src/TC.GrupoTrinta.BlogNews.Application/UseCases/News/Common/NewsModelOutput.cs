using DomainEntity = TC.GrupoTrinta.BlogNews.Domain.Entity;

namespace TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
public class NewsModelOutput
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public DateTime CreateAt { get; set; }

    public NewsModelOutput(
        Guid id,
        string title,
        string description,
        string author,
        DateTime publicationDate,
        DateTime createAt
    )
    {
        Id = id;
        Title = title;
        Description = description;
        Author = author;
        PublicationDate = publicationDate;
        CreateAt = createAt;
    }

    public static NewsModelOutput FromNews(DomainEntity.News news)
        => new(
            news.Id,
            news.Title,
            news.Content,
            news.Author,
            news.PublicationDate,
            news.CreateAt
        );

    public static List<NewsModelOutput> FromNewsList(List<DomainEntity.News> news)
    {
        var listNews = new List<NewsModelOutput>();
        return listNews = news.Select(x => FromNews(x)).ToList();
    }
}
