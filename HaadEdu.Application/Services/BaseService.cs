using HaadEdu.Domain.Repositories;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace HaadEdu.Application.Services;

public class BaseService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer<AppLanguage> localizer)
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
    protected readonly IStringLocalizer _localizer = localizer;
}
