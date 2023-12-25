using HaadEdu.Domain.Repositories;
using AutoMapper;

namespace HaadEdu.Application.Services;

public class BaseService(IUnitOfWork unitOfWork, IMapper mapper)
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
}
