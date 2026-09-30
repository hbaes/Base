namespace Base
{
    /// <summary>
    /// class managing a Calendar Week
    /// </summary>
    public class CalendarWeek
    {
        /// <summary>
        /// The year number.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The years week number.
        /// </summary>
        public int Week { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="year">year number</param>
        /// <param name="week">years week number</param>
        public CalendarWeek(int year, int week)
        {
            this.Year = year;
            this.Week = week;
        }
    }
}
