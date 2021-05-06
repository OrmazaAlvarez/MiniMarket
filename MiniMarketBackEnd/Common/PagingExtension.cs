using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMarketBackEnd.Common
{
    public static class PagingExtension
    {
        public static DataCollection<T> GetPaged<T>(this List<T> query, int page, int take, int Total)
        {
            var originalPages = page;
            page--;
            if (page > 0) 
                page *= take;
            var result = new DataCollection<T>
            {
                Items = query.ToList(),
                Total = Total,
                Page = originalPages
            };

            if (result.Total > 0)
                result.Pages = (result.Total / take) + 1;

            return result;
        }
    }
}
