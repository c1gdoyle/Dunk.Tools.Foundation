using System;
using System.Linq.Expressions;
using System.Reflection;
using Dunk.Tools.Foundation.Extensions;

namespace Dunk.Tools.Foundation.Expressions
{
    /// <summary>
    /// Provides methods for generating a property getter or setter functions 
    /// using expression-trees
    /// </summary>
    public static class CompiledExpressionFactory
    {
        /// <summary>
        /// For a given property anme and type creates a delegate for getting 
        /// the property value from an instance of the type.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>
        /// <typeparam name="TProperty">The return type of the property on the object.</typeparam>
        /// <param name="propertyName">The name of the property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and returns the 
        /// specified property value.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> parameter was null or empty.</exception>
        public static Func<TObject, TProperty> CreatePropertyGetter<TObject, TProperty>(string propertyName)
        {
            propertyName.ThrowIfNullOrEmpty(nameof(propertyName), string.Format(
                "Unable to generate getter function for type {0}. propertyName parameter cannot be null",
                typeof(TObject).Name));

            ParameterExpression entity = Expression.Parameter(typeof(TObject), "entity");

            MemberExpression propertyGetter = Expression.Property(entity, propertyName);

            Expression<Func<TObject, TProperty>> lambda =
                Expression.Lambda<Func<TObject, TProperty>>(propertyGetter, entity);

            return lambda.Compile();
        }

        /// <summary>
        /// For a given property anme and type creates a delegate for getting 
        /// the property value from an instance of the type.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>
        /// <typeparam name="TProperty">The return type of the property on the object.</typeparam>
        /// <param name="property">The property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and returns the 
        /// specified property value.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="property"/> parameter was null.</exception>
        public static Func<TObject, TProperty> CreatePropertyGetter<TObject, TProperty>(PropertyInfo property)
        {
            property.ThrowIfNull(nameof(property), string.Format(
                "Unable to generate getter function for type {0}. propertyName parameter cannot be null",
                typeof(TObject).Name));

            MethodInfo getterMethod = property.GetMethod;
            ParameterExpression entity = Expression.Parameter(typeof(TObject));

            MemberExpression propertyGetter = Expression.Property(entity, getterMethod);

            Expression<Func<TObject, TProperty>> lambda =
                Expression.Lambda<Func<TObject, TProperty>>(propertyGetter, entity);

            return lambda.Compile();
        }

        /// <summary>
        /// For a given property name and type creates a delegate for getting 
        /// the property value from an instance of the type and casting the result.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>
        /// <typeparam name="TResult">The return type of the delegate.</typeparam>
        /// <param name="propertyName">The name of the property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and casts the 
        /// specified property value to <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> parameter was null or empty.</exception>
        public static Func<TObject, TResult> CreatePropertyGetterWithCast<TObject, TResult>(string propertyName)
        {
            propertyName.ThrowIfNullOrEmpty(nameof(propertyName), string.Format(
                "Unable to generate getter function for type {0}. propertyName parameter cannot be null",
                typeof(TObject).Name));

            ParameterExpression entity = Expression.Parameter(typeof(TObject), "entity");

            MemberExpression propertyGetter = Expression.Property(entity, propertyName);
            UnaryExpression castToType = Expression.Convert(propertyGetter, typeof(TResult));

            Expression<Func<TObject, TResult>> lambda =
                Expression.Lambda<Func<TObject, TResult>>(castToType, entity);

            return lambda.Compile();
        }


        /// <summary>
        /// For a given property and type creates a delegate for getting 
        /// the property value from an instance of the type and casting the result.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>
        /// <typeparam name="TResult">The return type of the delegate.</typeparam>
        /// <param name="property">The name of the property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and casts the 
        /// specified property value to <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="property"/> parameter was null.</exception>
        public static Func<TObject, TResult> CreatePropertyGetterWithCast<TObject, TResult>(PropertyInfo property)
        {
            property.ThrowIfNull(nameof(property), string.Format(
                "Unable to generate getter function for type {0}. propertyName parameter cannot be null",
                typeof(TObject).Name));

            MethodInfo getterMethod = property.GetMethod;
            ParameterExpression entity = Expression.Parameter(typeof(TObject));

            MemberExpression propertyGetter = Expression.Property(entity, getterMethod);
            UnaryExpression castToType = Expression.Convert(propertyGetter, typeof(TResult));

            Expression<Func<TObject, TResult>> lambda =
                Expression.Lambda<Func<TObject, TResult>>(castToType, entity);

            return lambda.Compile();
        }

        /// <summary>
        /// For a given property name and type creates a delegate for setting 
        /// the property value on an instance of the type.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>
        /// <typeparam name="TProperty">The return type of the property on the object.</typeparam>
        /// <param name="propertyName">The property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and <typeparamref name="TProperty"/> and 
        /// sets the specified property on the instance.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> parameter was null or empty.</exception>
        public static Action<TObject, TProperty> CreatePropertySetter<TObject, TProperty>(string propertyName)
        {
            propertyName.ThrowIfNullOrEmpty(nameof(propertyName), string.Format(
                "Unable to generate setter function for type {0}. propertyName parameter cannot be null",
                typeof(TObject).Name));

            ParameterExpression entity = Expression.Parameter(typeof(TObject));
            ParameterExpression property = Expression.Parameter(typeof(TProperty), propertyName);

            MemberExpression propertyGetter = Expression.Property(entity, propertyName);
            BinaryExpression propertySetter = Expression.Assign(propertyGetter, property);

            Expression<Action<TObject, TProperty>> lambda =
                Expression.Lambda<Action<TObject, TProperty>>(propertySetter, entity, property);

            return lambda.Compile();
        }

        /// <summary>
        /// For a given property and type creates a delegate for setting 
        /// the property value on an instance of the type.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>
        /// <typeparam name="TProperty">The return type of the property on the object.</typeparam>
        /// <param name="property">The property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and <typeparamref name="TProperty"/> and 
        /// sets the specified property on the instance.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="property"/> parameter was null.</exception>
        public static Action<TObject, TProperty> CreatePropertySetter<TObject, TProperty>(PropertyInfo property)
        {
            property.ThrowIfNull(nameof(property), string.Format(
                "Unable to generate setter function for type {0}. property parameter cannot be null",
                typeof(TObject).Name));

            MethodInfo setterMethod = property.SetMethod;

            ParameterExpression entity = Expression.Parameter(typeof(TObject));
            ParameterExpression propertyParam = Expression.Parameter(typeof(TProperty), property.Name);

            MethodCallExpression propertySetter = Expression.Call(entity, setterMethod, propertyParam);

            Expression<Action<TObject, TProperty>> lambda =
                Expression.Lambda<Action<TObject, TProperty>>(propertySetter, entity, propertyParam);

            return lambda.Compile();
        }

        /// <summary>
        /// For a given property name and type creates a delegate for casting a parameter 
        /// and setting the property value on an instance of the type.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>        
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="propertyName">The property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and <typeparamref name="TParam"/>, casts the 
        /// parameter and sets the specified property on the instance.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> parameter was null or empty.</exception>
        public static Action<TObject, TParam> CreatePropertySetterCast<TObject, TParam>(string propertyName)
        {
            propertyName.ThrowIfNullOrEmpty(nameof(propertyName), string.Format(
                "Unable to generate setter function for type {0}. propertyName parameter cannot be null",
                typeof(TObject).Name));

            ParameterExpression entity = Expression.Parameter(typeof(TObject));
            ParameterExpression property = Expression.Parameter(typeof(TParam), propertyName);

            MemberExpression propertyGetter = Expression.Property(entity, propertyName);
            UnaryExpression cast = Expression.Convert(property, propertyGetter.Type);
            BinaryExpression propertySetter = Expression.Assign(propertyGetter, cast);

            Expression<Action<TObject, TParam>> lambda =
                Expression.Lambda<Action<TObject, TParam>>(propertySetter, entity, property);

            return lambda.Compile();
        }

        /// <summary>
        /// For a given property and type creates a delegate for casting a parameter 
        /// and setting the property value on an instance of the type.
        /// </summary>
        /// <typeparam name="TObject">The type of object we are dealing with.</typeparam>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="property">The property we are getting the value for.</param>
        /// <returns>
        /// A delegate that takes an instance of <typeparamref name="TObject"/> and <typeparamref name="TParam"/>, casts and 
        /// sets the specified property on the instance.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="property"/> parameter was null.</exception>
        public static Action<TObject, TParam> CreatePropertySetterCast<TObject, TParam>(PropertyInfo property)
        {
            property.ThrowIfNull(nameof(property), string.Format(
                "Unable to generate setter function for type {0}. property parameter cannot be null",
                typeof(TObject).Name));

            ParameterExpression entity = Expression.Parameter(typeof(TObject));
            ParameterExpression propertyParam = Expression.Parameter(typeof(TParam), property.Name);

            MemberExpression propertyGetter = Expression.Property(entity, property.Name);
            UnaryExpression cast = Expression.Convert(propertyParam, property.PropertyType);
            BinaryExpression propertySetter = Expression.Assign(propertyGetter, cast);

            Expression<Action<TObject, TParam>> lambda =
                Expression.Lambda<Action<TObject, TParam>>(propertySetter, entity, propertyParam);

            return lambda.Compile();
        }
    }
}
