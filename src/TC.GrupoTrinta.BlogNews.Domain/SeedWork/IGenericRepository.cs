namespace TC.GrupoTrinta.BlogNews.Domain.SeedWork;

public interface IGenericRepository<TAggregate> : IRepository where TAggregate : AggregateRoot
{
    public Task Insert(TAggregate aggregate, CancellationToken cancellationToken);

    public Task<TAggregate> GetById(Guid id, CancellationToken cancellationToken);

    public Task<List<TAggregate>> GetAll(CancellationToken cancellationToken);
}
