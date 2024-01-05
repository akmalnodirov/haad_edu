using HaadEdu.Domain.Entities;

namespace HaadEdu.Application.Extension;

public static class CollectionExtention
{
    public static IQueryable<T> TPagedList<T>(this IQueryable<T> source, PaginationParams @params)
    {
        return @params.pageIndex > 0 && @params.PageSize >= 0 
            ? source.Take(((@params.pageIndex -1) * @params.PageSize)..@params.PageSize)
            : source;
    }

}
