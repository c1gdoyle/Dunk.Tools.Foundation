using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for calculating business days between <see cref="DateTime"/> 
    /// values.
    /// </summary>
    public static class BusinessDateTimeExtensions
    {
        /// <summary>
        /// Returns whether or not the original datetime is a business day.
        /// </summary>
        /// <param name="date">The original date.</param>
        /// <returns><c>true</c> if the date is a businessday; otherwise <c>false</c>.</returns>
        /// <remarks>
        /// Note that be 'business days' we mean normal weekdays excluding Saturday and Sunday. This method only takes into 
        /// account weekends during its' calculation and does not include logic for accounting for any holidays.
        /// </remarks>
        public static bool IsBuisnessDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that is the next business day to 
        /// the original datetime.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance whose value is the sum of the <paramref name="date"/> and one 
        /// business day.
        /// </returns>
        /// <remarks>
        /// Note that be 'business days' we mean normal weekdays excluding Saturday and Sunday. This method only takes into 
        /// account weekends during its' calculation and does not include logic for accounting for any holidays.
        /// </remarks>
        public static DateTime GetNextBusinessDay(this DateTime date)
        {
            return AddBusinessDays(date, 1);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that is the prior business day to 
        /// the original datetime.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance whose value is the sum of the <paramref name="date"/> minus one 
        /// business day.
        /// </returns>
        /// <remarks>
        /// Note that be 'business days' we mean normal weekdays excluding Saturday and Sunday. This method only takes into 
        /// account weekends during its' calculation and does not include logic for accounting for any holidays.
        /// </remarks>
        public static DateTime GetPriorBusiness(this DateTime date)
        {
            return SubtractBusinessDays(date, 1);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of business days to the orignial date.
        /// </summary>
        /// <param name="date">The original date.</param>
        /// <param name="days">A number of whole business days. The value of this parameter cannot be negative.</param>
        /// <returns>
        /// A <see cref="DateTime "/> instance whose value is the sum of the <paramref name="date"/> and the number of business 
        /// days represented by the <paramref name="days"/>.
        /// </returns>
        /// <remarks>
        /// Note that be 'business days' we mean normal weekdays excluding Saturday and Sunday. This method only takes into 
        /// account weekends during its' calculation and does not include logic for accounting for any holidays.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="days"/> was negative.</exception>
        public static DateTime AddBusinessDays(this DateTime date, int days)
        {
            if (days < 0)
            {
                throw new ArgumentException($"{nameof(days)} parameter cannot be negative", nameof(days));
            }

            if (days == 0)
            {
                //no difference just return original date
                return date;
            }

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                //adjust if original date is Saturday
                date = date.AddDays(2);
                days = days - 1;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                //adjust if original date is Sunday
                date = date.AddDays(1);
                days = days - 1;
            }

            //add full weeks
            date = date.AddDays(days / 5 * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays > 5)
            {
                //do the extra days push it to after Friday, next weekend
                extraDays = extraDays + 2;
            }
            return date.AddDays(extraDays);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that subtracts the specified number of business days from the original datetime.
        /// </summary>
        /// <param name="date">The original datetime.</param>
        /// <param name="days">The number of whole business days. The value of this parameter cannot be negative.</param>
        /// <returns>
        /// A <see cref="DateTime"/> instance whose value is the sum of the <paramref name="date"/> minus the number of 
        /// business days represented by <paramref name="days"/>.
        /// </returns>
        /// <remarks>
        /// Note that be 'business days' we mean normal weekdays excluding Saturday and Sunday. This method only takes into 
        /// account weekends during its' calculation and does not include logic for accounting for any holidays.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="days"/> was negative.</exception>
        public static DateTime SubtractBusinessDays(this DateTime date, int days)
        {
            if (days < 0)
            {
                throw new ArgumentException($"{nameof(days)} parameter cannot be negative", nameof(days));
            }

            if (days == 0)
            {
                //no difference just return original date
                return date;
            }

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                //adjust if original date is Saturday
                date = date.AddDays(-1);
                days = days - 1;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                //adjust if original date is Sunday
                date = date.AddDays(-2);
                days = days - 1;
            }

            //subtract full weeks
            date = date.AddDays(-(days / 5 * 7));
            int extraDays = days % 5;

            if ((int)date.DayOfWeek - extraDays < 1)
            {
                //do the extra days push it to before Monday, prior weekend
                extraDays = extraDays + 2;
            }
            return date.AddDays(-extraDays);
        }

        /// <summary>
        /// Calculates the number of business days between two dates.
        /// </summary>
        /// <param name="start">The start date of the interval.</param>
        /// <param name="end">The end date of the interval.</param>
        /// <returns>
        /// An <see cref="int"/> representing the number of business days between the <paramref name="start"/> and <paramref name="end"/> dates.
        /// </returns>
        /// <remarks>
        /// Note that be 'business days' we mean normal weekdays excluding Saturday and Sunday. This method only takes into 
        /// account weekends during its' calculation and does not include logic for accounting for any holidays.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="start"/> date is later than <paramref name="end"/> date.</exception>
        public static int GetBusinessDays(this DateTime start, DateTime end)
        {
            DateTime firstDay = start.Date;
            DateTime lastDay = end.Date;

            if (firstDay > lastDay)
            {
                throw new ArgumentException($"Invalid dates. Start date {start} cannot be later than End date {end}");
            }
            if (firstDay == lastDay)
            {
                //same date so just return 0
                return 0;
            }

            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;

            int firstDayOfWeek = firstDay.DayOfWeek == DayOfWeek.Sunday ?
                7 : (int)firstDay.DayOfWeek;
            int lastDaysOfWeek = lastDay.DayOfWeek == DayOfWeek.Sunday ?
                7 : (int)lastDay.DayOfWeek;

            //find out if there are weekends during the time exceeding full weeks
            if (businessDays > fullWeekCount * 7)
            {
                if (lastDaysOfWeek < firstDayOfWeek)
                {
                    lastDaysOfWeek += 7;
                }

                if (firstDayOfWeek <= 6)
                {
                    if (lastDaysOfWeek >= 7)
                    {
                        //Both Saturday and Sunday are in the remaining time interval
                        businessDays = businessDays - 2;
                    }
                    else if (lastDaysOfWeek >= 6)
                    {
                        //Only Saturday is in the remaining time interval
                        businessDays = businessDays - 1;
                    }
                }
                else if (firstDayOfWeek <= 7 && lastDaysOfWeek >= 7)
                {
                    businessDays = businessDays - 1;
                }
            }

            //subtract the weekends during the full weeks in the interval
            businessDays = businessDays - (2 * fullWeekCount);

            return businessDays;
        }
    }
}
