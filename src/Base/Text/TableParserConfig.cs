using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Text
{
    /// <summary>
    /// Configuration class for TableParser
    /// </summary>
    public class TableParserConfig
    {

        /// <summary>
        /// Gets or sets the column headers.
        /// </summary>
        /// <value>
        /// The column headers.
        /// </value>
        public string[] ColumnHeaders { get; set; }

        /// <summary>
        /// Gets or sets the maximum width of the column.
        /// </summary>
        /// <value>
        /// The maximum width of the column.
        /// </value>
        public int[] ColumnMaxWidth { get; set; }

        /// <summary>
        /// Gets or sets the width of the effective column.
        /// </summary>
        /// <value>
        /// The width of the effective column.
        /// </value>
        public int[] EffectiveColumnWidth { get; set; }

        /// <summary>
        /// Gets or sets the length of the line break.
        /// </summary>
        /// <value>
        /// The length of the line break.
        /// </value>
        public int[] LineBreakLength { get; set; }

    }
}
