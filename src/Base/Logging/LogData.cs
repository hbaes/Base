namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class containing log data.
    /// </summary>
    public class LogData : Dictionary<string, object>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LogData"/> class.
        /// </summary>
        public LogData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogData"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public LogData(IDictionary<string, object> values)
            : base(values)
        {
        }
        #endregion
    }
}
