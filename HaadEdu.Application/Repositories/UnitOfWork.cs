using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace HaadEdu.Application.Repositories;

public class UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger) : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _dbContext = context;
    private readonly ILogger _logger = logger;

    public IRoleRepository RoleRepository { get; } = new RoleRepository(context, logger);

    public async Task<bool> CompleteAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose() => _dbContext.Dispose();
}
