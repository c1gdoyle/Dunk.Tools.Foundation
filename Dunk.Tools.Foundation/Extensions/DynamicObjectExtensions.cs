using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods over a dynamic object.
    /// </summary>
    public static class DynamicObjectExtensions
    {
        /// <summary>
        /// Converst a standard C# <see cref="object"/> into an equivalent <see cref="ExpandoObject"/>.
        /// </summary>
        /// <param name="obj">The original object.</param>
        /// <returns>
        /// An <see cref="ExpandoObject"/> that contains all the public, instance properties of the orignal object.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> parameter was null.</exception>
        public static ExpandoObject ConvertToExpando(this object obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj), 
                    $"Unable to convert to dynamic object. {nameof(obj)} cannot be null");
            }

            var properties = obj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //Add properties to new Expando
            ExpandoObject expando = new ExpandoObject();
            foreach (PropertyInfo prop in properties)
            {
                AddOrSetProperty(expando, prop.Name, prop.GetValue(obj));
            }

            return expando;
        }

        /// <summary>
        /// Adds or sets a property on the <see cref="ExpandoObject"/> instance using a specified property value.
        /// </summary>
        /// <param name="expando">The <see cref="ExpandoObject"/> instance.</param>
        /// <param name="propertyName">The name of the property to add or set.</param>
        /// <param name="propertyValue">The value to set the property to, if the property already exists its' value will be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="expando"/> or <paramref name="propertyName"/> parameter was null.</exception>
        public static void AddOrSetProperty(this ExpandoObject expando, string propertyName, object propertyValue)
        {
            if(expando == null)
            {
                throw new ArgumentNullException(nameof(expando), 
                    $"Unable to convert to add property to dynamic object. {nameof(expando)} cannot be null");
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName), 
                    $"Unable to convert to add property to dynamic object. {nameof(propertyName)} cannot be null or empty");
            }

            var expandoDict = expando as IDictionary<string, object>;

            expandoDict.AddOrUpdate(propertyName, k => propertyValue, (k, v) => propertyValue);
        }

        /// <summary>
        /// Adds or sets a event on the <see cref="ExpandoObject"/> instance using a specified event handler.
        /// </summary>
        /// <param name="expando">The <see cref="ExpandoObject"/> instance.</param>
        /// <param name="eventName">The name of the event to add or set.</param>
        /// <param name="eventHandler">The valye to set the eventhandler to, if event already exists its' value will be updated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="expando"/>, <paramref name="eventName"/> or <paramref name="eventHandler"/> parameter was null.</exception>
        public static void AddOrSetEvent(this ExpandoObject expando, string eventName, Action<object, EventArgs> eventHandler)
        {
            if(expando == null)
            {
                throw new ArgumentNullException(nameof(expando),
                    $"Unable to convert to add event to dynamic object. {nameof(expando)} cannot be null");
            }
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName),
                    $"Unable to convert to add event to dynamic object. {nameof(eventName)} cannot be null");
            }
            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler),
                    $"Unable to convert to add event to dynamic object. {nameof(eventHandler)} cannot be null");
            }

            var expandoDict = expando as IDictionary<string, object>;

            expandoDict.AddOrUpdate(eventName, k => eventHandler, (k, v) => eventHandler);

        }
    }
}
