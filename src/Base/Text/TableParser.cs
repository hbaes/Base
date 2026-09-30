namespace Base.Text
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Table Parser class
    /// </summary>
    public static class TableParser
    {

        private static TableParserConfig config= new TableParserConfig();

        /// <summary>
        /// To the string table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="columnHeaders">The column headers.</param>
        /// <param name="valueSelectors">The value selectors.</param>
        /// <returns></returns>
        public static string ToStringTable<T>(
            this IEnumerable<T> values,
            string[] columnHeaders,
            params Func<T, object>[] valueSelectors)
        {
            return ToStringTable(values.ToArray(), columnHeaders, valueSelectors);
        }

        /// <summary>
        /// To the string table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="valueSelectors">The value selectors.</param>
        /// <returns></returns>
        public static string ToStringTable<T>(
            this IEnumerable<T> values,
            params Expression<Func<T, object>>[] valueSelectors)
        {
            var headers = valueSelectors.Select(func => GetProperty(func).Name).ToArray();
            var selectors = valueSelectors.Select(exp => exp.Compile()).ToArray();
            return ToStringTable(values, headers, selectors);
        }

        /// <summary>
        /// To the string table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="columnHeaders">The column headers.</param>
        /// <param name="valueSelectors">The value selectors.</param>
        /// <returns></returns>
        public static string ToStringTable<T>(
          this T[] values,
          string[] columnHeaders,
          params Func<T, object>[] valueSelectors)
        {
            Debug.Assert(columnHeaders.Length == valueSelectors.Length);

            var arrValues = new string[values.Length + 1, valueSelectors.Length];
            config.ColumnHeaders = new string[valueSelectors.Length];
            
            // Fill headers
            for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
            {
                arrValues[0, colIndex] = columnHeaders[colIndex];
                config.ColumnHeaders[colIndex] = columnHeaders[colIndex];
            }

            // Fill table rows
            for (int rowIndex = 1; rowIndex < arrValues.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
                {
                    arrValues[rowIndex, colIndex] = valueSelectors[colIndex]
                      .Invoke(values[rowIndex - 1]).ToString();
                }
            }

            return ToStringTable(arrValues);
        }

        /// <summary>
        /// To the string table.
        /// </summary>
        /// <param name="arrValues">The arr values.</param>
        /// <returns></returns>
        public static string ToStringTable(this string[,] arrValues)
        {
            int[] maxColumnsWidth = GetMaxColumnsWidth(arrValues);
            var headerSpliter = new string('-', maxColumnsWidth.Sum(i => i + 3) - 1);

            var sb = new StringBuilder();
            for (int rowIndex = 0; rowIndex < arrValues.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
                {
                    // Print cell
                    string cell = arrValues[rowIndex, colIndex];
                    cell = cell.PadRight(maxColumnsWidth[colIndex]);
                    if (arrValues[rowIndex, colIndex] == "---")
                    {
                        sb.Append(" | ");
                        sb.Append(new String('-', maxColumnsWidth[colIndex]));
                    }
                    else
                    {
                        sb.Append(" | ");
                        sb.Append(cell);
                    }
                }

                // Print end of line
                sb.Append(" | ");
                sb.AppendLine();

                // Print splitter
                if (rowIndex == 0)
                {
                    sb.AppendFormat(" |{0}| ", headerSpliter);
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        private static int[] GetMaxColumnsWidth(string[,] arrValues)
        {
            var maxColumnsWidth = new int[arrValues.GetLength(1)];
            config.ColumnMaxWidth = new int[arrValues.GetLength(1)];
            for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
            {
                for (int rowIndex = 0; rowIndex < arrValues.GetLength(0); rowIndex++)
                {
                    int newLength = arrValues[rowIndex, colIndex].Length;
                    
                    int oldLength = maxColumnsWidth[colIndex];

                    if (newLength > oldLength)
                    {
                        maxColumnsWidth[colIndex] = newLength;
                        config.ColumnMaxWidth[colIndex] = newLength;
                    }
                }
            }

            return maxColumnsWidth;
        }

        private static PropertyInfo GetProperty<T>(Expression<Func<T, object>> expresstion)
        {
            if (expresstion.Body is UnaryExpression)
            {
                if ((expresstion.Body as UnaryExpression).Operand is MemberExpression)
                {
                    return ((expresstion.Body as UnaryExpression).Operand as MemberExpression).Member as PropertyInfo;
                }
            }

            if ((expresstion.Body is MemberExpression))
            {
                return (expresstion.Body as MemberExpression).Member as PropertyInfo;
            }
            return null;
        }

        //static void Main(string[] args)
        //{
        //    IEnumerable<Tuple<int, string, string>> authors =
        //      new[]
        //    {
        //        Tuple.Create(1, "Isaac", "Asimov"),
        //        Tuple.Create(2, "Robert", "Heinlein"),
        //        Tuple.Create(3, "Frank", "Herbert"),
        //        Tuple.Create(4, "Aldous", "Huxley"),
        //    };

        //    Console.WriteLine(authors.ToStringTable(
        //      new[] { "Id", "First Name", "Surname" },
        //      a => a.Item1, a => a.Item2, a => a.Item3));

        //    /* Result:        
        //    | Id | First Name | Surname  |
        //    |----------------------------|
        //    | 1  | Isaac      | Asimov   |
        //    | 2  | Robert     | Heinlein |
        //    | 3  | Frank      | Herbert  |
        //    | 4  | Aldous     | Huxley   |
        //    */
        //}

    }
}
