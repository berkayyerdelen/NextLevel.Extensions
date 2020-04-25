using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NextLevel.Extensions
{
    public class DictionaryFixture<Tkey, TValue>
    {
        public DictionaryFixture(Tkey key, TValue value)
        {
            Key = key;
            Value = value;
        }
        public Tkey Key { get; set; }
        public TValue Value { get; set; }
    }
    public static class CollectionExtensions
    {
        public static List<DictionaryFixture<TKey, TValue>> ToList<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary)
        {

            var t =dictionary.Select(x => new DictionaryFixture<TKey, TValue>(x.Key,x.Value));
            return t.ToList();

        }
        public static List<T> RemoveDuplicates<T>(this List<T> input)
        {
            Dictionary<T, int> uniqueStore = new Dictionary<T, int>();
            List<T> finalList = new List<T>();

            foreach (T currValue in input)
            {
                if (!uniqueStore.ContainsKey(currValue))
                {
                    uniqueStore.Add(currValue, 0);
                    finalList.Add(currValue);
                }
            }
            return finalList;
        }
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            return query.Skip(skipCount).Take(maxResultCount);
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }
    }

   
}