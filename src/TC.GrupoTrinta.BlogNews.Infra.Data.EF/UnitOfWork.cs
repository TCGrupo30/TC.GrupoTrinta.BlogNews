using TC.GrupoTrinta.BlogNews.Application.Interfaces;

namespace TC.GrupoTrinta.BlogNews.Infra.Data.EF;
public class UnitOfWork : IUnitOfWork
{
    private readonly BlogNewsDbContext _context;

    public UnitOfWork(BlogNewsDbContext context)
        => _context = context;

    public Task Commit(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);

    public Task Rollback(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
