using Microsoft.EntityFrameworkCore;

namespace Common.Config
{
    public static class PagingExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(
           this IQueryable<T> query,
           int page = 0,
           int take = 100,
           string column = "",
           string order = "desc"
       ) where T : class
        {
            var result = new DataCollection<T>();

            take = (take == 0) ? 100 : take;

            result.Total = await query.CountAsync();
            result.Page = page!;

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(
                    Math.Ceiling(
                        Convert.ToDecimal(result.Total) / take
                    )
                );

                if (order == "asc" && column != "")
                {
                    query = query.OrderBy(y => EF.Property<object>(y, column));
                }
                else if (order == "desc" && column != "")
                {
                    query = query.OrderByDescending(y => EF.Property<object>(y, column));
                }

                result.Items = await query.Skip((page) * take).Take(take).ToListAsync();

                result.Page = result.Page + 1;
            }

            return result;
        }
    }
}
