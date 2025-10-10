namespace BNPL.Domain.IRepository;

public interface ITransactionManager
{
    Task<IAsyncDisposable> BeginTransactionAsync(CancellationToken ct = default);
    Task CommitAsync(CancellationToken ct = default);
    Task RoleBackAsync(CancellationToken ct = default);
}
