using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HaadEdu.Domain.Repositories;

namespace HaadEdu.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController(IUnitOfWork unitOfWork, IMapper mapper) : Controller
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
}
