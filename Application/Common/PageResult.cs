namespace Application.Common
{
    public class PageResult<T>
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);
        public bool HasNextPage => Page < TotalPages;
        public bool HasPreviousPage => Page > 1;
        public IEnumerable<T>? Data { get; set; }
    }
}