using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
using TC.GrupoTrinta.BlogNews.Domain.Repository;

namespace TC.GrupoTrinta.BlogNews.Application.UseCases.News.GetNews
{
    public class GetByIdNews : IGetByIdNews
    {
        private readonly INewsRepository _newsRepository;

        public GetByIdNews(
            INewsRepository newsRepository
        )
        {
            _newsRepository = newsRepository;
        }

        public async Task<NewsModelOutput> Handle(GetByIdNewsInput input, CancellationToken cancellationToken)
        {
            return NewsModelOutput.FromNews(await _newsRepository.GetById(input.Id, cancellationToken));
        }
    }
}
