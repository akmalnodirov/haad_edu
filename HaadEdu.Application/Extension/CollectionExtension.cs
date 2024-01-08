using HaadEdu.Domain.Entities;

namespace HaadEdu.Application.Extension;

public static class CollectionExtension
{
    public static IQueryable<T> TPagedList<T>(this IQueryable<T> source, PaginationParams @params)
    {
        return @params.PageIndex > 0 && @params.PageSize >= 0 
            ? source.Take(((@params.PageIndex -1) * @params.PageSize)..@params.PageSize)
            : source;
    }

}
