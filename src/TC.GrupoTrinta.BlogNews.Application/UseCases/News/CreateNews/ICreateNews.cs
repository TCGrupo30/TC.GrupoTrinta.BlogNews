using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.GrupoTrinta.BlogNews.Application.UseCases.News.Common;

namespace TC.GrupoTrinta.BlogNews.Application.UseCases.News.CreateNews;
public interface ICreateNews : IRequestHandler<CreateNewsInput, NewsModelOutput>
{
}
