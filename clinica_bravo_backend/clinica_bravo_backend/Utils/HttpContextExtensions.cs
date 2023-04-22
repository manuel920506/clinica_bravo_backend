using Microsoft.EntityFrameworkCore; 

namespace clinica_bravo_backend.Utils {
    public static class HttpContextExtensions
    {
        public async static Task InsertPagingParametersInHeader<T>(this HttpContext httpContext,
            IQueryable<T> queryable)
        {
            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Add("countTotalRecords", count.ToString());
        }
    }
}
