using System.Xml.Linq;
using TC.GrupoTrinta.BlogNews.Domain.SeedWork;

namespace TC.GrupoTrinta.BlogNews.Domain.Entity;
public class News : AggregateRoot
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public DateTime CreateAt { get; set; }


    public News(string title, string description, string author, DateTime publicationDate)
        : base()
    {
        Title = title;
        Description = description;
        Author = author;
        PublicationDate = publicationDate;
        CreateAt = DateTime.Now;
    }
}
