using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="Type"/> instance.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets a specified attribute from the type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An instance of <typeparamref name="TAttribute"/> if it was found on the type; otherwise null.
        /// </returns>
        public static TAttribute GetAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(type)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets a specified attribute from the member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="member">The member.</param>
        /// <returns>
        /// An instance of <typeparamref name="TAttribute"/> if it was found on the member; otherwise null.
        /// </returns>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo member)
            where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(member)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets a collection of specified attributes from the type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of <typeparamref name="TAttribute"/> if any were found on the type; otherwise an empty array.
        /// </returns>
        public static TAttribute[] GetAttributes<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            type.ThrowIfNull(nameof(type));

            Attribute[] attributes = Attribute.GetCustomAttributes(type, typeof(TAttribute), false);

            return attributes as TAttribute[];
        }

        /// <summary>
        /// Gets a collection of specified attributes from the member.
        /// </summary>
        /// <typeparam name="TAttribute">The member of attribute to get.</typeparam>
        /// <param name="member">The member.</param>
        /// <returns>
        /// An array of <typeparamref name="TAttribute"/> if any were found on the member; otherwise an empty array.
        /// </returns>
        public static TAttribute[] GetAttributes<TAttribute>(this MemberInfo member)
            where TAttribute : Attribute
        {
            member.ThrowIfNull(nameof(member));

            Attribute[] attributes = Attribute.GetCustomAttributes(member, typeof(TAttribute), false);

            return attributes as TAttribute[];
        }

        /// <summary>
        /// Gets extension methods for this type.
        /// </summary>
        /// <param name="extendedType">The type whose extension methods we are looking for.</param>
        /// <returns>
        /// A collection of <see cref="MethodInfo"/>'s representing the extension methods of this type.
        /// </returns>
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type extendedType)
        {
            extendedType.ThrowIfNull(nameof(extendedType));

            List<Type> types = new List<Type>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                types.AddRange(assembly.GetTypes());
            }
            return types
                .Where(t => t.IsSealed && !t.IsGenericType && !t.IsNested)
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                .Where(m => m.IsDefined(typeof(ExtensionAttribute), false) &&
                m.GetParameters()[0].ParameterType == extendedType);
        }

        /// <summary>
        /// Gets extension methods for this type in a specified assembly.
        /// </summary>
        /// <param name="extendedType">The type whose extension methods we are looking for.</param>
        /// <param name="assembly"> The assembly which we are looking for the extension methods in.</param>
        /// <returns>
        /// A collection of <see cref="MethodInfo"/>'s representing the extension methods of this type.
        /// </returns>
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type extendedType, Assembly assembly)
        {
            extendedType.ThrowIfNull(nameof(extendedType));
            assembly.ThrowIfNull(nameof(assembly));

            return assembly.GetTypes()
                .Where(t => t.IsSealed && !t.IsGenericType && !t.IsNested)
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                .Where(m => m.IsDefined(typeof(ExtensionAttribute), false) &&
                m.GetParameters()[0].ParameterType == extendedType);
        }

        /// <summary>
        /// Gets a sequence of base types implemented by a specified type including 
        /// the type itself.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        public static IEnumerable<Type> GetBaseTypes(this Type type)
        {
            return GetBaseTypes(type, true);
        }

        /// <summary>
        /// Gets a sequence of base types implemented by a specified type with a flag
        /// indicating whether the type itself should be included.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeSelf">A flag indicating whether the type itself should be included.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        public static IEnumerable<Type> GetBaseTypes(this Type type, bool includeSelf)
        {
            if (includeSelf)
            {
                yield return type;
            }
            Type localType = type.BaseType;
            while (localType != null)
            {
                yield return localType;
                localType = localType.BaseType;
            }
        }


        /// <summary>
        /// Gets a sequence of base types implemented by a specified type (excluding object) including 
        /// the type itself.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        public static IEnumerable<Type> GetBaseTypesExcludingObject(this Type type)
        {
            return GetBaseTypesExcludingObject(type, true);
        }

        /// <summary>
        /// Gets a sequence of base types implemented by a specified type (excluding object) with a flag
        /// indicating whether the type itself should be included.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeSelf">A flag indicating whether the type itself should be included.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        public static IEnumerable<Type> GetBaseTypesExcludingObject(this Type type, bool includeSelf)
        {
            if (includeSelf &&
                type != typeof(object))
            {
                yield return type;
            }
            Type localType = type.BaseType;
            while (localType != null &&
                localType != typeof(object))
            {
                yield return localType;
                localType = localType.BaseType;
            }
        }

        /// <summary>
        /// Gets all instance properties of a type in a flat hierarchy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of properties from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class propertoes to base class properties,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class properties to derived class properties.
        /// </remarks>
        public static PropertyInfo[] GetAllProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var properties = new List<PropertyInfo>();

                var considered = new List<Type>(new Type[] { type });
                var queue = new Queue<Type>(new Type[] { type });

                while (queue.Count != 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface))
                        {
                            continue;
                        }
                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var newProperties = subType.GetProperties(BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance)
                        .Where(x => !properties.Contains(x));

                    properties.InsertRange(0, newProperties);
                }
                return properties.ToArray();
            }
            return type.GetProperties(BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets all public instance properties of a type in a flat hierarchy.
        /// </summary>
        /// <param name="type">The typeo.</param>
        /// <returns>
        /// An array of properties from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class propertoes to base class properties,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class properties to derived class properties.
        /// </remarks>
        public static PropertyInfo[] GetAllPublicProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var properties = new List<PropertyInfo>();

                var considered = new List<Type>(new Type[] { type });
                var queue = new Queue<Type>(new Type[] { type });

                while (queue.Count != 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface))
                        {
                            continue;
                        }
                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var newProperties = subType.GetProperties(BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance)
                        .Where(x => !properties.Contains(x));

                    properties.InsertRange(0, newProperties);
                }
                return properties.ToArray();
            }
            return type.GetProperties(BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);
        }
    }
}
