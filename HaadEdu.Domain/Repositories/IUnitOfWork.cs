
namespace HaadEdu.Domain.Repositories;

public interface IUnitOfWork
{
    IRoleRepository RoleRepository { get; }
    IRolePermissionRepository RolePermissionRepository { get; }
    Task<bool> CompleteAsync();

    Task BeginTransaction();

    Task CommitAsync();

    Task RollBackAsync();
}
