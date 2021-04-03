using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for calculating weighted-average for
    /// an <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class WeightedAverageExtensions
    {
        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static decimal? WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, decimal?> valueSelector, Func<T, decimal?> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            decimal? totalValue = 0.0m;
            decimal? totalWeight = 0.0m;
            checked
            {
                foreach (T item in sequence)
                {
                    decimal? currentWeight = weightSelector(item);
                    decimal? currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static decimal WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, decimal> valueSelector, Func<T, decimal> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            decimal totalValue = 0.0m;
            decimal totalWeight = 0.0m;
            checked
            {
                foreach (T item in sequence)
                {
                    decimal currentWeight = weightSelector(item);
                    decimal currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static double? WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, double?> valueSelector, Func<T, double?> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            double? totalValue = 0.0;
            double? totalWeight = 0.0;
            checked
            {
                foreach (T item in sequence)
                {
                    double? currentWeight = weightSelector(item);
                    double? currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static double WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, double> valueSelector, Func<T, double> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            double totalValue = 0.0;
            double totalWeight = 0.0;
            checked
            {
                foreach (T item in sequence)
                {
                    double currentWeight = weightSelector(item);
                    double currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static float? WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, float?> valueSelector, Func<T, float?> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            float? totalValue = 0.0f;
            float? totalWeight = 0.0f;
            checked
            {
                foreach (T item in sequence)
                {
                    float? currentWeight = weightSelector(item);
                    float? currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static float WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, float> valueSelector, Func<T, float> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            float totalValue = 0.0f;
            float totalWeight = 0.0f;
            checked
            {
                foreach (T item in sequence)
                {
                    float currentWeight = weightSelector(item);
                    float currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static double? WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, int?> valueSelector, Func<T, int?> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            double? totalValue = 0;
            double? totalWeight = 0;
            checked
            {
                foreach (T item in sequence)
                {
                    int? currentWeight = weightSelector(item);
                    int? currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static double WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, int> valueSelector, Func<T, int> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            double totalValue = 0;
            double totalWeight = 0;
            checked
            {
                foreach (T item in sequence)
                {
                    int currentWeight = weightSelector(item);
                    int currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return (totalValue / totalWeight);
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static double? WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, long?> valueSelector, Func<T, long?> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            double? totalValue = 0;
            double? totalWeight = 0;
            checked
            {
                foreach (T item in sequence)
                {
                    long? currentWeight = weightSelector(item);
                    long? currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return totalValue / totalWeight;
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }

        /// <summary>
        /// Calculates the weighted-average from a specified sequence.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="sequence">The sequence containg the items.</param>
        /// <param name="valueSelector">A delegate for selecting the value from an item.</param>
        /// <param name="weightSelector">A delegate for selecting the weight from an item.</param>
        /// <returns>
        /// The weighted-average of the sequence of values.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sequence"/>, <paramref name="valueSelector"/> or <paramref name="weightSelector"/> was null.</exception>
        /// <exception cref="InvalidOperationException">The sequence contains no elements or weighted average is 0.</exception>
        public static double WeightedAverage<T>(this IEnumerable<T> sequence, Func<T, long> valueSelector, Func<T, long> weightSelector)
        {
            sequence.ThrowIfNull(nameof(sequence));
            valueSelector.ThrowIfNull(nameof(valueSelector));
            weightSelector.ThrowIfNull(nameof(weightSelector));

            double totalValue = 0;
            double totalWeight = 0;
            checked
            {
                foreach (T item in sequence)
                {
                    long currentWeight = weightSelector(item);
                    long currentValue = valueSelector(item);

                    totalValue += currentValue * currentWeight;
                    totalWeight += currentWeight;
                }
            }

            if (totalWeight != 0)
            {
                return (totalValue / totalWeight);
            }
            throw new InvalidOperationException("Unable to calculate average-weight, total weight cannot be 0");
        }
    }
}
