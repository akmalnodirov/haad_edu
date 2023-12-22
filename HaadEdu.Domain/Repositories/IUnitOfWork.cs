namespace HaadEdu.Domain.Repositories;

public interface IUnitOfWork
{
    Task<bool> CompleteAsync();
}
