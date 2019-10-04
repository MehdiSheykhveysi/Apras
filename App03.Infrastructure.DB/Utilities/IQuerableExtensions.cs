using App02.Contract.Resource;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace App03.Infrastructure.DB.Utilities
{
    public static class IQuerableExtensions
    {

        public static IQueryable<TSource> Paginate<TSource, TKey>(this IQueryable<TSource> source, IPaginationInfo pagination, Expression<Func<TSource, TKey>> orderByKeySelector)
        {
            return source.OrderBy(orderByKeySelector)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize);
        }
    }
}
