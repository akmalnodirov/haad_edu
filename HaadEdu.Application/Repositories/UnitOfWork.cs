using HaadEdu.Domain.Repositories;

namespace HaadEdu.Application.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public Task<bool> CompleteAsync()
    {
        throw new NotImplementedException();
    }
}
