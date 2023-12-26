using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Transactions;

namespace HaadEdu.Application.Repositories;

public class UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger) : IUnitOfWork, IDisposable
{
    public readonly AppDbContext _dbContext = context;
    private readonly ILogger _logger = logger;
    private IDbContextTransaction _transaction;

    public IRoleRepository RoleRepository { get; } = new RoleRepository(context, logger);
    public IRolePermissionRepository RolePermissionRepository { get; } = new RolePermissionRepository(context, logger);

    public async Task BeginTransaction()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
    }

    public async Task RollBackAsync()
    {
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;

    }

    public void Dispose() => _dbContext.Dispose();
}
