using AutoMapper;
using HaadEdu.Application.Dtos.Role;
using HaadEdu.Domain.Entities;

namespace HaadEdu.Application.MappingProfile;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Role, AddRoleResponse>()
            .ForMember(dest => dest.RolePermissions, opt => opt.MapFrom(src => src.RolePermissions));

        CreateMap<AddRoleRequest, AddRoleResponse>()
            .ForMember(dest => dest.RolePermissions, opt => opt.MapFrom(src => src.RolePermissions));
    }
}
