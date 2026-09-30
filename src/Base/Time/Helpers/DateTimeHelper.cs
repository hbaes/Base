namespace Base.Time.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Threading;
    using System.Diagnostics;

    /// <summary>
    /// Helper class managing Date/Time DateTime functions.
    /// </summary>
    /// <remarks>Uses <see cref="Argument"/> class for Argument validation.</remarks>
    /// <remarks>
    /// <c>History:</c>
    /// <list type="table">
    ///   <listheader>
    ///     <term>Date</term>
    ///     <term>User</term>
    ///     <term>Description</term>
    ///   </listheader>
    ///   <item>
    ///     <term>2013.02.23</term><term>hbaes</term><term>finished documentation.</term>
    ///   </item>
    ///   <item>
    ///     <term>2013.01.02</term><term>hbaes</term><term>added <see cref="FormatTime"/>.</term>
    ///   </item>
    /// </list>
    /// </remarks>
    public static class DateTimeHelper
    {

        /// <summary>
        /// calculate elapsed Time from starting DateTime Object to DateTimeObject in Seconds
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns>time difference in seconds.</returns>
        /// <remarks>Uses <see cref="Argument"/> class for Argument validation.</remarks>
        public static long ElapsedTimeInSec(DateTime startTime, DateTime endTime)
        {
            Argument.IsNotNull("startTime", startTime);
            Argument.IsNotNull("endTime", endTime);
            TimeSpan interval = endTime - startTime;
            return interval.Days * 24 * 60 * 60 + interval.Hours * 60 * 60 + interval.Minutes * 60 + interval.Seconds;
        }

        /// <summary>
        /// calculate elapsed Time from starting DateTime Object to DateTimeObject in Milliseconds
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns>time difference in milliseconds</returns>
        /// <remarks>Uses <see cref="Argument"/> class for Argument validation.</remarks>
        public static long ElapsedTimeInMS(DateTime startTime, DateTime endTime)
        {
            Argument.IsNotNull("startTime", startTime);
            Argument.IsNotNull("endTime", endTime);
            TimeSpan interval = endTime - startTime;
            long seconds = interval.Days * 24 * 60 * 60 + interval.Hours * 60 * 60 + interval.Minutes * 60 + interval.Seconds;
            return seconds * 1000 + interval.Milliseconds;
        }

        /// <summary>
        /// calculate Elapsed Time in Seconds between Start Time and now
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <returns>time difference in seconds</returns>
        /// <remarks>Uses <see cref="Argument"/> class for Argument validation.</remarks>
        public static long ElapsedTimeInSec(DateTime startTime)
        {
            Argument.IsNotNull("startTime", startTime);
            return ElapsedTimeInSec(startTime, DateTime.Now);
        }

        /// <summary>
        /// Calculate full months count between 2 dates
        /// </summary>
        /// <param name="Date1">The date1.</param>
        /// <param name="Date2">The date2.</param>
        /// <returns>count of months between teh two dates.</returns>
        public static int GetMonthsBetweenDates(DateTime Date1, DateTime Date2)
        {
            // Beide Daten in einer Liste speichern und sortieren 
            List<DateTime> period = new List<DateTime>() { Date1, Date2 };
            period.Sort(DateTime.Compare);

            // Monate zählen
            int months;
            for (months = 0; period[0].AddMonths(months + 1).CompareTo(period[1]) <= 0; months++) ;

            return months;
        }

        /// <summary>
        /// Get Calendar Week Number
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>year´s calendar week number</returns>
        /// <remarks>Uses <see cref="Argument"/> class for Argument validation.</remarks>
        /// <remarks>
        /// if no <paramref name="culture"/> is given the following default values are used:
        /// <c>Thread.CurrentThread.CurrentCulture</c>.
        /// Depending on this value The <see cref="CalendarWeekRule"/> and <see cref="DateTimeFormatInfo.FirstDayOfWeek"/>
        /// are used for calulation.
        /// </remarks>
        public static int GetCalendarWeek(DateTime date, CultureInfo culture = null)
        {
            Argument.IsNotNull("date", date);
            // culture given or Thread Current Culture
            culture = culture ?? Thread.CurrentThread.CurrentCulture;
            return culture.Calendar.GetWeekOfYear(date, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek);
        }

        /// <summary>
        /// Get First Day of given Week Number
        /// </summary>
        /// <param name="yearNumber">between 0 and 3000</param>
        /// <param name="weekNumber">between 1 and 53</param>
        /// <param name="culture">The culture.</param>
        /// <returns>DateTime with the first day of this week.</returns>
        /// <remarks>Uses <see cref="Argument"/> class for Argument validation.</remarks>
        /// <remarks>
        /// if no <paramref name="culture"/> is given the following default values are used:
        /// <c>Thread.CurrentThread.CurrentCulture</c>.
        /// Depending on this value the <see cref="DateTimeFormatInfo.FirstDayOfWeek"/>
        /// is used for calulation.
        /// </remarks>
        public static DateTime GetFirstDayOfWeek(int yearNumber, int weekNumber, CultureInfo culture = null)
        {
            Argument.IsNotNull("yearNumber", yearNumber);
            Argument.IsNotNull("weekNumber", weekNumber);
            Argument.IsNotOutOfRange("yearNumber", yearNumber, 0, 3000);
            Argument.IsNotOutOfRange("weekNumber", weekNumber, 1, 53);
            // culture given or Thread Current Culture
            culture = culture ?? Thread.CurrentThread.CurrentCulture;

            DateTime dtFirstOfYear = new DateTime(yearNumber, 1, 1, culture.Calendar);
            DateTime dtTargetDay = culture.Calendar.AddWeeks(dtFirstOfYear, weekNumber);
            DayOfWeek dtFirstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;

            while (dtTargetDay.DayOfWeek != dtFirstDayOfWeek)
            {
                dtTargetDay = dtTargetDay.AddDays(-1);
            }

            return dtTargetDay;
        }

        /// <summary>
        /// Gets the first day of the month.
        /// </summary>
        /// <param name="givenDate">The given date.</param>
        /// <returns>
        /// the first day of the month
        /// </returns>
        public static DateTime GetFirstDayOfMonth(DateTime givenDate)
        {
            return new DateTime(givenDate.Year, givenDate.Month, 1);
        }

        /// <summary>
        /// Gets the last day of month.
        /// </summary>
        /// <param name="givenDate">The given date.</param>
        /// <returns>
        /// the last day of the month
        /// </returns>
        public static DateTime GetTheLastDayOfMonth(DateTime givenDate)
        {
            return GetFirstDayOfMonth(givenDate).AddMonths(1).Subtract(new TimeSpan(1, 0, 0, 0, 0));
        }


        /// <summary>
        /// Calculate Season from specific Date
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// enum Seasons.Spring, Seasons.Summer, ...
        /// </returns>
        /// <remarks>
        /// calculation is based of fix dates:
        /// <list type="">
        /// <item>Winter: 22.12. - 20.03.</item>
        /// <item>Spring: 21.03. - 20.06.</item>
        /// <item>Summer: 21.06. - 22.09.</item>
        /// <item>Autumn: 23.09. - 21.12.</item>
        /// </list>
        /// </remarks>
        public static Seasons GetSeason(DateTime date)
        {
            Argument.IsNotNull("date", date);
            float value = (float)date.Month + ((float)date.Day / 100);       // <month>.<day(2 digit)>
#if DEBUG
            Debug.WriteLine("Date: {0} = {1}", date, value);
#endif
            if (value < 3.21 || value >= 12.22) return Seasons.Winter;           // Winter
            if (value < 6.21) return Seasons.Spring; // Spring
            if (value < 9.23) return Seasons.Summer; // Summer            
            return Seasons.Autumn;   // Autumn
        }

        /// <summary>
        /// format the time in a friendly format for logging
        /// </summary>
        /// <param name="milliseconds">the time represented in milliseconds</param>
        /// <returns>
        /// the log friendly time
        /// </returns>
        /// <example>
        /// <code>
        /// FormatTime(100) == '100 ms'
        /// 
        /// FormatTime(50000) == '50 sec'
        /// </code>
        /// </example>
        public static string FormatTime(long milliseconds)
        {
            var sign = (milliseconds < 0) ? "-" : string.Empty;
            if (sign == "-")
                milliseconds = -milliseconds;
            var time = new TimeSpan(milliseconds * TimeSpan.TicksPerMillisecond);

            if (time.TotalMilliseconds < 1000)
                return string.Format("{0}{1} ms", sign, milliseconds);

            if (time.TotalSeconds < 60)
                return string.Format("{0}{1:f2} sec", sign, time.TotalSeconds);

            if (time.TotalMinutes < 60)
                return string.Format("{0}{1:f2} min", sign, time.TotalMinutes);

            if (time.TotalHours < 24)
                return string.Format("{0}{1:f2} hr", sign, time.TotalHours);

            return string.Format("{0}{1:f2} days", sign, time.TotalDays);
        }


        /// <summary>
        /// Format the Time given in double milliseconds
        /// - maybe from average calculation -
        /// to human readable format
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>time in human readable format <c>00h:00m:00s:000ms</c></returns>
        public static string FormatTimeHumanReadable(double time)
        {
            long milliseconds = Convert.ToInt32(time);
            return FormatTimeHumanReadable(milliseconds);
        }


        /// <summary>
        /// Format the Time given in milliseconds to human readable format
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <returns>time in human readable format <c>00h:00m:00s:000ms</c></returns>
        public static string FormatTimeHumanReadable(long milliseconds)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(milliseconds);
            return FormatTimeHumanReadable(t);
        }

        /// <summary>
        /// Format the TimeSpan given to human readable format
        /// 00h:00m:00s:000ms
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <returns></returns>
        public static string FormatTimeHumanReadable(TimeSpan timeSpan)
        {
            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    timeSpan.Hours,
                                    timeSpan.Minutes,
                                    timeSpan.Seconds,
                                    timeSpan.Milliseconds);
            return answer;
        }

        /// <summary>
        /// Format the Date (Short date) depending on given Culture
        /// If no culture selected take en-US
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string FormatShortDate(DateTime date, CultureInfo culture = null)
        {
            if (culture == null)
                culture = new CultureInfo("en-US");
            return date.ToString(culture.DateTimeFormat.ShortDatePattern);
        }

        /// <summary>
        /// Format the Date (Long date) depending on given Culture
        /// If no culture selected take en-US
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string FormatLongDate(DateTime date, CultureInfo culture = null)
        {
            if (culture == null)
                culture = new CultureInfo("en-US");
            return date.ToString(culture.DateTimeFormat.LongDatePattern);
        }

        /// <summary>
        /// Format the Time (Short Time) depending on given culture.
        /// If no culture selected take en-US
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string FormatShortTime(DateTime date, CultureInfo culture = null)
        {
            if (culture == null)
                culture = new CultureInfo("en-US");
            return date.ToString(culture.DateTimeFormat.ShortTimePattern);
        }

        /// <summary>
        /// Format the Time (Short Time) depending on given culture.
        /// If no culture selected take en-US
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string FormatLongTime(DateTime date, CultureInfo culture = null)
        {
            if (culture == null)
                culture = new CultureInfo("en-US");
            return date.ToString(culture.DateTimeFormat.LongTimePattern);
        }

        /// <summary>
        /// Retuns a DateTime with the Time set to date minimum time.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>
        /// datetime object with mnimum time set.
        /// </returns>
        public static DateTime ToDateMinTime(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// Return calendar week for given dateTime.
        /// </summary>
        /// <param name="dateTime">the datetime.</param>
        /// <param name="culture">Specific culture or default will be taken.</param>
        /// <returns>
        /// calendar week for given dateTime
        /// </returns>
        public static int ToCalendarWeek(this DateTime dateTime, CultureInfo culture = null)
        {
            return GetCalendarWeek(dateTime, culture);
        }

        /// <summary>
        /// Returns an DateTimeHelper.Seasons enum value for Season of dateTime
        /// </summary>
        /// <param name="dateTime">the datetime.</param>
        /// <returns>
        ///   <see cref="Seasons" /> value of given datetime.
        /// </returns>
        public static Seasons ToSeason(this DateTime dateTime)
        {
            return GetSeason(dateTime);
        }

        /// <summary>
        /// Convert DateTime to Unix TimeStamp
        /// (Seconds from 1.1.1970)
        /// </summary>
        /// <param name="dateTime">The DateTime</param>
        /// <returns>
        /// Unix Timestamp
        /// </returns>
        public static int ToTimestamp(this DateTime dateTime)
        {
            return Convert.ToInt32((dateTime - new DateTime(1970, 1, 1)).TotalSeconds);
        }

        /// <summary>
        /// Returns string with ShortDate.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <param name="culture">Specific culture or default will be taken.</param>
        /// <returns>
        /// datetime in short string format <see cref="DateTimeHelper.FormatShortDate"/>
        /// </returns>
        public static string ToShortDateString2(this DateTime dateTime, CultureInfo culture = null)
        {
            return FormatShortDate(dateTime, culture);
        }

        /// <summary>
        /// Returns string with LongDate.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <param name="culture">Specific culture or default will be taken.</param>
        /// <returns>
        /// datetime in LongDate format <see cref="DateTimeHelper.FormatLongDate"/>.
        /// </returns>
        public static string ToLongDateString2(this DateTime dateTime, CultureInfo culture = null)
        {
            return FormatLongDate(dateTime, culture);
        }

        /// <summary>
        /// returns string with ShortTime.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <param name="culture">Specific culture or default will be taken.</param>
        /// <returns>
        /// datetime in ShortTime format <see cref="DateTimeHelper.FormatShortTime"/>.
        /// </returns>
        public static string ToShortTimeString2(this DateTime dateTime, CultureInfo culture = null)
        {
            return FormatShortTime(dateTime, culture);
        }

        /// <summary>
        /// Returns string with LongTime.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <param name="culture">Specific culture or default will be taken.</param>
        /// <returns>
        /// datetime in LongTime format <see cref="DateTimeHelper.FormatLongTime"/>.
        /// </returns>
        public static string ToLongTimeString2(this DateTime dateTime, CultureInfo culture = null)
        {
            return FormatLongTime(dateTime, culture);
        }

    }
}
