using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="IQueryable{T}"/> instance.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Returns the values in a sequence whose result key values fall between the supplied
        /// lower and upper limites.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys to compare against.</typeparam>
        /// <param name="source">The sequence.</param>
        /// <param name="keySelector">A predicate used to select the key value to compare against the lower and upper limits.</param>
        /// <param name="lower">The lower value of the key selector.</param>
        /// <param name="upper">The upper value of the key select.</param>
        /// <returns>
        /// A <see cref="IQueryable{TSource}"/> sequence whose selected values fall within the range of
        /// the <paramref name="lower"/> and <paramref name="upper"/> limits.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> was null.</exception>
        public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector, TKey lower, TKey upper)
            where TKey : IComparable<TKey>
        {
            if(source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if(keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            Expression key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());

            Expression lowerBound = Expression.GreaterThanOrEqual(key, Expression.Constant(lower));
            Expression upperBound = Expression.LessThanOrEqual(key, Expression.Constant(upper));

            Expression andClause = Expression.AndAlso(lowerBound, upperBound);

            Expression<Func<TSource, bool>> whereClause =
                Expression.Lambda<Func<TSource, bool>>(andClause, keySelector.Parameters);

            return source.Where(whereClause);
        }

        /// <summary>
        /// Sorts the elements of a sequence into ascending or descending order based on a specified 
        /// property on the elements.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="orderByProperty">The name of the property on the <typeparamref name="TSource"/> to sort by.</param>
        /// <param name="desc">A flag to indicate whether or not to sort by descending order.</param>
        /// <returns>
        /// A <see cref="IQueryable{T}"/> whose elements are sorted according to the <paramref name="orderByProperty"/> and <paramref name="desc"/>.
        /// </returns>
        public static IQueryable<TSource> Orderby<TSource>(this IQueryable<TSource> source, string orderByProperty, bool desc)
        {
            return Orderby(source, typeof(TSource).GetProperty(orderByProperty), desc);
        }

        /// <summary>
        /// Sorts the elements of a sequence into ascending or descending order based on a specified 
        /// property on the elements.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="orderByProperty">The property on the <typeparamref name="TSource"/> to sort by.</param>
        /// <param name="desc">A flag to indicate whether or not to sort by descending order.</param>
        /// <returns>
        /// A <see cref="IQueryable{T}"/> whose elements are sorted according to the <paramref name="orderByProperty"/> and <paramref name="desc"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="orderByProperty"/> was null.</exception>
        public static IQueryable<TSource> Orderby<TSource>(this IQueryable<TSource> source, PropertyInfo orderByProperty, bool desc)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (orderByProperty == null)
            {
                throw new ArgumentNullException(nameof(orderByProperty));
            }

            string command = desc ? "OrderByDescending" : "OrderBy";

            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "p");
            Expression propertyAccess = Expression.MakeMemberAccess(parameter, orderByProperty);
            Expression orderByExpression = Expression.Lambda(propertyAccess, parameter);

            Expression resultExpression = Expression.Call(typeof(Queryable), command,
                new Type[] { typeof(TSource), orderByProperty.PropertyType },
                source.Expression,
                Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<TSource>(resultExpression);
        }
    }
}
