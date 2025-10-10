using BNPL.Domain.IRepository;
using BNPL.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace BNPL.Infrastructure.Repository.Repositories;

public class TransactionManager(BNPLDBContext context, IDbContextTransaction transaction) : ITransactionManager
{
    public async Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken ct = default)
    {
        transaction = await context.Database.BeginTransactionAsync(ct);
        return transaction;
    }

    public async Task CommitAsync(CancellationToken ct = default)
    {
        await context.SaveChangesAsync(ct);
        await transaction.CommitAsync(ct);
        await transaction.DisposeAsync();
    }

    public async Task RoleBackAsync(CancellationToken ct = default)
    {
        await transaction.RollbackAsync(ct);
        await transaction.DisposeAsync();
    }
}
