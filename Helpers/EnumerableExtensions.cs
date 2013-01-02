using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantPOI.Helpers
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer = null)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            return first.ExceptByIterator(second, keySelector, keyComparer);
        }
        private static IEnumerable<TSource> ExceptByIterator<TSource, TKey>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
        {
            var keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);
            return first.Where(item => keys.Add(keySelector(item)));
        }
    }
}
