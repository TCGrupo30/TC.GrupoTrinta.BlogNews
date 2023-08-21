using MediatR;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;


namespace TC.GrupoTrinta.BlogNews.Application.UseCases.News.GetNews
{
    public interface IGetByIdNews : IRequestHandler<GetByIdNewsInput, NewsModelOutput>
    {
    }
}
