using TC.GrupoTrinta.BlogNews.Domain.SeedWork;

namespace TC.GrupoTrinta.BlogNews.Domain.Entity;
public class News : AggregateRoot
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Author { get; private set; }
    public DateTime PublicationDate { get; private set; }
    public DateTime CreateAt { get; private set; }


    public News(string title, string content, string author, DateTime publicationDate)
        : base()
    {
        Title = title;
        Content = content;
        Author = author;
        PublicationDate = publicationDate;
        CreateAt = DateTime.Now;

        ValidationDomain();
    }

    private void ValidationDomain()
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(Title), "É importante fornecer um título");
        DomainExceptionValidation.When(Title.Length < 5 || Title.Length > 255, "O título deve ter um comprimento mínimo de 5 caracteres e não pode exceder 255 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(Content), "O conteúdo da notícia deve ser preenchido");
        DomainExceptionValidation.When(string.IsNullOrEmpty(Author), "É necessário fornecer informações sobre o autor da notícia");

        DomainExceptionValidation.When(DateTime.Now < PublicationDate, "A data de publicação deve ser igual ou posterior à data atual");

    }
}
