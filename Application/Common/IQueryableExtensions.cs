namespace Application.Common
{
    public static class IQueryableExtensions
    {
        public static async Task<PageResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = query.Count();
            var data = query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PageResult<T>()
            {
                Page = page,
                Count = totalCount,
                PageSize = pageSize,
                Data = data
            };
        }
    }
}