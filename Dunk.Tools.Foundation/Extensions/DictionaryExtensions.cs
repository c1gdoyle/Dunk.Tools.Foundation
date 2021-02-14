using System;
using System.Collections.Generic;
using System.Linq;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for a <see cref="IDictionary{TKey, TValue}"/> instance.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if the key does not already exist.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <returns>
        /// The value for the key. This will be either the existing value for the key 
        /// if the key is already in the dictionary, or the new default TValue created 
        /// if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : new()
        {
            return dictionary.GetOrAdd(key, k => new TValue());
        }

        /// <summary>
        /// Adds key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if the key does not already exist.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <returns>
        /// The value for the key. This will be either the existing value for the key 
        /// if the key is already in the dictionary, or the new value returned by the
        /// <paramref name="valueFactory"/> if the key was not in the dictionary.
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
            where TValue : new()
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = valueFactory(key);
                dictionary.Add(key, value);
            }
            return value;
        }

        /// <summary>
        /// Adds key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if the key does not already exists, 
        /// or updates a key/value pair in the <see cref="IDictionary{TKey, TValue}"/> if the key already exists.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="addValue">The value to be added.</param>
        /// <param name="updateFactory">The function used to generate a new value for an existing key based on the key's existing value.</param>
        /// <returns>
        /// The new value for the key. This will either be the new added value (if the key was absent) 
        /// or the result of the <paramref name="updateFactory"/> (if the key was present).
        /// </returns>
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateFactory)
        {
            return dictionary.AddOrUpdate(key, k => addValue, updateFactory);
        }

        /// <summary>
        /// Adds key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if the key does not already exists, 
        /// or updates a key/value pair in the <see cref="IDictionary{TKey, TValue}"/> if the key already exists.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="addFactory">The function used to generate a value for the absent key.</param>
        /// <param name="updateFactory">The function used to generate a new value for an existing key based on the key's existing value.</param>
        /// <returns>
        /// The new value for the key. This will either be the new added value (if the key was absent) 
        /// or the result of the <paramref name="updateFactory"/> (if the key was present).
        /// </returns>
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> addFactory, Func<TKey, TValue, TValue> updateFactory)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                value = updateFactory(key, value);
                dictionary[key] = value;
            }
            else
            {
                value = addFactory(key);
                dictionary.Add(key, value);
            }
            return value;
        }

        /// <summary>
        /// Gets the value associated with the specified key or a specified default.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">A default value of <typeparamref name="TValue"/></param>
        /// <returns>
        /// The value associated with the specified key if the key is found; otherwise <paramref name="defaultValue"/>.
        /// </returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        /// <summary>
        /// Gets the value associated with the specified key or a specified default.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValueFactory">A delegate for creating a default value of <typeparamref name="TValue"/>.</param>
        /// <returns>
        /// The value associated with the specified key if the key is found; otherwise result of <paramref name="defaultValueFactory"/>.
        /// </returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> defaultValueFactory)
        {
            return GetValueOrDefault(dictionary, key, defaultValueFactory());
        }

        /// <summary>
        /// Merges an array of dictionaries into a single dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionaries">The dictionaries to merge.</param>
        /// <returns>
        /// A <see cref="IDictionary{TKey, TValue}"/> instance that contains the combined kets and values of the supplied
        /// <paramref name="dictionaries"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dictionaries"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dictionaries"/> contained a duplicate key.</exception>
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue>[] dictionaries)
        {
            dictionaries.ThrowIfNull(nameof(dictionaries),
                $"Unable to merge dictionaries. {nameof(dictionaries)} parameter cannot be null.");

            return dictionaries.SelectMany(dict => dict)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        /// <summary>
        /// Merges an array of dictionaries into a single dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionaries">The dictionaries to merge.</param>
        /// <returns>
        /// A <see cref="IDictionary{TKey, TValue}"/> instance that contains the combined kets and values of the supplied
        /// <paramref name="dictionaries"/>. If the dictionaries contained a duplicate key the value associated with the key
        /// will be the first value matched to the key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dictionaries"/> is null.</exception>
        public static IDictionary<TKey, TValue> SafeMerge<TKey, TValue>(this IDictionary<TKey, TValue>[] dictionaries)
        {
            dictionaries.ThrowIfNull(nameof(dictionaries),
                $"Unable to merge dictionaries. {nameof(dictionaries)} parameter cannot be null.");

            return dictionaries.SelectMany(dict => dict)
                .ToLookup(kvp => kvp.Key, kvp => kvp.Value)
                .ToDictionary(group => group.Key, group => group.First());
        }
    }
}
