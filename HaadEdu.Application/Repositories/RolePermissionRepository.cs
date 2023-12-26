﻿using HaadEdu.Domain.Entities;
using HaadEdu.Domain.Repositories;
using HaadEdu.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace HaadEdu.Application.Repositories;

public class RolePermissionRepository(AppDbContext context, ILogger logger) : GenericRepository<RolePermission>(context, logger), IRolePermissionRepository
{
}