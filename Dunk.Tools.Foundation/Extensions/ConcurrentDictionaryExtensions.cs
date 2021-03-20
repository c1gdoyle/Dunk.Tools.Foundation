using System;
using System.Collections.Concurrent;

namespace Dunk.Tools.Foundation.Extensions
{
    public static class ConcurrentDictionaryExtensions
    {
        /// <summary>
        /// Adds a key/value pair to a <see cref="ConcurrentDictionary{TKey, TValue}"/> if the key does not already exist.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The <see cref="ConcurrentDictionary{TKey, TValue}"/> to which the key should be added.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">The function used to generate the value for the key.</param>
        /// <returns>
        /// The value for the key. This will be either the existing value for the key
        /// if the key is already in the dictionary, or the new value for the key
        /// returned by the valueFactory if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAddSafe<TKey, TValue>(this ConcurrentDictionary<TKey, Lazy<TValue>> dictionary, TKey key, Func<TKey, TValue> valueFactory)
        {
            Lazy<TValue> lazy = dictionary.GetOrAdd(key, new Lazy<TValue>(() => valueFactory(key)));
            return lazy.Value;
        }

        /// <summary>
        /// Adds a key/value pair to a <see cref="ConcurrentDictionary{TKey, TValue}"/> if the key does not already exist.
        /// Or updates the key/value pair if the key already exits.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The <see cref="ConcurrentDictionary{TKey, TValue}"/> to which the key should be added.</param>
        /// <param name="key">The key of the element to add or update.</param>
        /// <param name="addValueFactory">The function to generate a value for the key if it does not already exists.</param>
        /// <param name="updateValueFactory">The function to update the value for the key if it already exits.</param>
        /// <returns>
        /// The value for the key. This will be either the updated value for the key
        /// returned by the updateValueFactory if the key is already in the dictionary, 
        /// or the new value for the key returned by the addValueFactory if the key was not in the dictionary.
        /// </returns>
        public static TValue AddOrUpdateSafe<TKey, TValue>(this ConcurrentDictionary<TKey, Lazy<TValue>> dictionary, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        {
            Lazy<TValue> lazy = dictionary.AddOrUpdate(key,
                new Lazy<TValue>(() => addValueFactory(key)),
                (k, oldValue) => new Lazy<TValue>(() => updateValueFactory(k, oldValue.Value)));

            return lazy.Value;
        }
    }
}
