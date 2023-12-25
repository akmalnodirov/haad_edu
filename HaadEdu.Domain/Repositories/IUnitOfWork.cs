namespace HaadEdu.Domain.Repositories;

public interface IUnitOfWork
{
    IRoleRepository RoleRepository { get; }
    Task<bool> CompleteAsync();
}
