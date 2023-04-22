using clinica_bravo_backend.DTOs;

namespace clinica_bravo_backend.Utils {
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginationDTO paginacionDTO)
        {
            return queryable
                .Skip((paginacionDTO.Page - 1) * paginacionDTO.RecordsForPage)
                .Take(paginacionDTO.RecordsForPage);
        }
    }
}
