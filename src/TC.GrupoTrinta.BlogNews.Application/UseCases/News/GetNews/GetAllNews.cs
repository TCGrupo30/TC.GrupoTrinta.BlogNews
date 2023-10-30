using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;
using TC.GrupoTrinta.BlogNews.Domain.Repository;

namespace TC.GrupoTrinta.BlogNews.Application.UseCases.News.GetNews
{
    public class GetAllNews : IGetAllNews
    {
        private readonly INewsRepository _newsRepository;

        public GetAllNews(
            INewsRepository newsRepository
        )
        {
            _newsRepository = newsRepository;
        }

        public async Task<List<NewsModelOutput>> Handle(GetAllNewsInput request, CancellationToken cancellationToken)
        {
            return NewsModelOutput.FromNewsList(await _newsRepository.GetAll(cancellationToken));
        }
    }
}
