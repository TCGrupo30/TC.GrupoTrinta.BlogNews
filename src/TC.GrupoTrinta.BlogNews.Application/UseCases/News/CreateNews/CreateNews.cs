using TC.GrupoTrinta.BlogNews.Application.Interfaces;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
using TC.GrupoTrinta.BlogNews.Domain.Repository;
using DomainEntity = TC.GrupoTrinta.BlogNews.Domain.Entity;

namespace TC.GrupoTrinta.BlogNews.Application.UseCases.News.CreateNews;
public class CreateNews : ICreateNews
{
    private readonly INewsRepository _newsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateNews(
        INewsRepository newsRepository,
        IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;
        _newsRepository = newsRepository;
    }

    public async Task<NewsModelOutput> Handle(CreateNewsInput input, CancellationToken cancellationToken)
    {
        var news = new DomainEntity.News(input.Title, input.Description, input.Author, input.PublicationDate);

        await _newsRepository.Insert(news, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return NewsModelOutput.FromNews(news);
    }
}
