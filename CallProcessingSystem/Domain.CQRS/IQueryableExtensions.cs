using System;
using System.Linq;

namespace Domain.CQRS
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IOrderedQueryable<T> source, int page, int countOnPage)
        {
            if (countOnPage <= 0) countOnPage = 25;
            if (page <= 0) page = 1;

            return source
                .Skip(CalculateSkipCountForPagination(page, countOnPage))
                .Take(countOnPage);
        }

        public static IQueryable<T> Page<T>(this IOrderedQueryable<T> source, int page, int countOnPage,
            out int allPages, out int count)
        {
            if (countOnPage <= 0) countOnPage = 25;
            if (page <= 0) page = 1;

            var skip = CalculateSkipCountForPagination(page, countOnPage);

            count = source.Count();
            var res = (double) count / countOnPage;
            allPages = Convert.ToInt32(Math.Ceiling(res));

            return source
                .Skip(skip)
                .Take(countOnPage);
        }

        public static IQueryable<T> Page<T>(this IOrderedQueryable<T> source, int page, int countOnPage,
            out int count)
        {
            if (countOnPage <= 0) countOnPage = 25;
            if (page <= 0) page = 1;

            var skip = CalculateSkipCountForPagination(page, countOnPage);

            count = source.Count();

            return source
                .Skip(skip)
                .Take(countOnPage);
        }

        private static int CalculateSkipCountForPagination(int page, int countOnPage)
        {
            return (page - 1) * countOnPage;
        }
    }
}