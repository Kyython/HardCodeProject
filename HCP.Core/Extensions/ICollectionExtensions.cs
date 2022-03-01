using System;
using System.Collections.Generic;
using System.Linq;

namespace HCP.Core.Extensions
{
    public static class ICollectionExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this ICollection<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            if (source == null)
                return new PagedList<T>(new List<T>(), pageIndex, pageSize);

            pageSize = Math.Max(pageSize, 1);

            var count = source.Count();

            var data = new List<T>();

            if (!getOnlyTotalCount)
                data.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());

            return new PagedList<T>(data, pageIndex, pageSize, count);
        }
    }
}
