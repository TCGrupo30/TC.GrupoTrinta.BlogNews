using MediatR;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;

namespace TC.GrupoTrinta.BlogNews.Application.UseCases.News.CreateNews;
public class CreateNewsInput : IRequest<NewsModelOutput>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }

    public CreateNewsInput() { }
    public CreateNewsInput(
        string title,
        string description,
        string author,
        DateTime publicationDate
    )
    {
        Title = title;
        Description = description ?? "";
        Author = author;
        PublicationDate = publicationDate;
    }
}
