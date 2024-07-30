namespace FIAP.Infrastructure.CrossCutting.Interfaces;
public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync();

    Task<bool> CommitAsync(bool detachAll);

    bool HasError();

    void ThereIsError();

    Task CommitTransactionAsync();

    void BeginTransaction();

    Task RollBackTransactionAsync();
}