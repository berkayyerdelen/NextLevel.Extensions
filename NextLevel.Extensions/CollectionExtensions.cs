using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NextLevel.Extensions
{
    /// <summary>
    /// It will be use in convertion of dictonary to list
    /// </summary>
    /// <typeparam name="TKey">Type of Key</typeparam>
    /// <typeparam name="TValue">Type of Value</typeparam>
    public class DictionaryFixture<TKey, TValue>
    {
        public DictionaryFixture(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
    public static class CollectionExtensions
    {
        /// <summary>
        /// Extension imp of dictionary to list
        /// </summary>
        /// <typeparam name="TKey">Generic Key type</typeparam>
        /// <typeparam name="TValue">Generic Key type</typeparam>
        /// <param name="dictionary">argument</param>
        /// <returns></returns>
        public static List<DictionaryFixture<TKey, TValue>> ToList<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary)
        {

            var source =dictionary.Select(x => new DictionaryFixture<TKey, TValue>(x.Key,x.Value));
            return source.ToList();

        }
        /// <summary>
        /// Removing the dubplicate values in collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Paging by via linq queries
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="query">Collection</param>
        /// <param name="skipCount">Skip parameter</param>
        /// <param name="maxResultCount">Max result of count</param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            return query.Skip(skipCount).Take(maxResultCount);
        }
        /// <summary>
        /// WhereIf condition with predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
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