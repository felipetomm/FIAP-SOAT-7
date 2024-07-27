using FIAP.Infrastructure.CrossCutting.Interfaces;

using Microsoft.EntityFrameworkCore.Storage;

namespace FIAP.Infrastructure.Data.Context;
public class UnitOfWork : IUnitOfWork
{
    private readonly object _padlock = new object();
    private bool _inAnotherTransaction;
    private bool _hasError;
    private IDbContextTransaction _trans;
    private readonly BaseDbContext _context;

    public UnitOfWork(BaseDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        if (_trans != null)
        {
            _inAnotherTransaction = true;
            return;
        }

        _hasError = false;

        lock (_padlock)
        {
            _trans ??= _context.Database.BeginTransaction();
        }
    }

    public Task<bool> CommitAsync()
    {
        return CommitAsync(false);
    }

    public async Task<bool> CommitAsync(bool detachAll)
    {
        if (_trans == null)
        {
            lock (_padlock)
            {
                _trans ??= _context.Database.BeginTransaction();
            }
        }

        try
        {
            var ret = (await _context.SaveChangesAsync()) > 0;

            if (detachAll)
                _context.DetachAll();

            return ret;
        }
        catch (Exception)
        {
            _hasError = true;
            throw;
        }
    }

    public async Task CommitTransactionAsync()
    {
        if (_inAnotherTransaction)
            return;

        if (_trans != null)
        {
            if (_hasError)
            {
                await _trans.RollbackAsync();
            }
            else
            {
                await _trans.CommitAsync();
            }
        }

        _hasError = false;
    }

    public async Task RollBackTransactionAsync()
    {
        if (_trans != null)
            await _trans.RollbackAsync();

        _hasError = false;
    }

    public bool HasError()
    {
        return _hasError;
    }

    public void ThereIsError()
    {
        _hasError = true;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}