using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    /// <summary>
    /// IEnumerable Extensions
    /// </summary>
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
    /// </list>
    /// </remarks>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Cop acomplete <see cref="IEnumerable"/> list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>element by element copy.</returns>
        public static IEnumerable<T> CopyList<T>(this IEnumerable source)
        {
            List<T> retVal = new List<T>();
            foreach (object obj in source)
            {
                try
                {
                    retVal.Add((T)obj);
                }
                catch { };
            }
            return retVal;
        }

        /// <summary>
        /// Get Index of item searched.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source list.</param>
        /// <param name="item">The item to find..</param>
        /// <returns>list index.</returns>
        public static int GetIndexOf<T>(this IEnumerable<T> source, T item)
        {
            int counter = 0;
            foreach (T obj in source)
            {
                if ((object)obj == (object)item)
                    return counter;

                counter++;
            }

            return -1;
        }

        /// <summary>
        /// count existance of the <paramref name="item"/> in the <paramref name="source"/> list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source list.</param>
        /// <param name="item">The item to count.</param>
        /// <returns>item count</returns>
        public static int CountContains<T>(this IEnumerable<T> source, T item)
        {
            int retVal = 0;

            foreach (T obj in source)
            {
                if (obj.Equals(item))
                    retVal++;
            }

            return retVal;
        }

        /// <summary>
        /// Gibt eine Auflistung aller Elemente der Unter-Listen zurück.
        /// </summary>
        /// <typeparam name="T">Der Typ der Elemente in den Unter-Listen.</typeparam>
        /// <param name="source">Die Auflistung der Unter-Auflistungen.</param>
        /// <returns>Eine Auflistung die die Elemente der übergebenen Unter-Listen zurück gibt.</returns>
        public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
        {
            return source.SelectMany(x => x);
        }

        /// <summary>
        /// Wählt ein einzelnes Element aus, dessen bestimmter Wert das Minimum aller bestimmter Werte ist.
        /// </summary>
        /// <typeparam name="TResult">Der Typ der Elemente in der Quellauflistung.</typeparam>
        /// <typeparam name="TComparable">Der Typ der zum Größenvergleich der Werte dient.</typeparam>
        /// <param name="source">Die Quellliste mit den Elementen.</param>
        /// <param name="predicate">Eine Funktion zum auswählen des bestimmten Wertes eines Elements.</param>
        /// <returns>Das Element aus <paramref name="source"/> dessen mit <paramref name="predicate"/> bestimmter Wert Minimal ist.</returns>
        /// <exception cref="System.ArgumentNullException">Wird ausgelöst, wenn einer der Parameter <c>null</c> ist.</exception>
        /// <exception cref="System.InvalidOperationException">Wird ausgelöst, wenn <paramref name="source"/> 
        /// kein Element enthält oder aber mehr als eines, dessen Wert minimal ist.</exception>
        public static TResult SingleMin<TResult, TComparable>(this IEnumerable<TResult> source, Func<TResult, TComparable> predicate)
            where TComparable : IComparable<TComparable>
        {
            return SelectMinMax(source, predicate, 1);
        }

        /// <summary>
        /// Wählt ein einzelnes Element aus, dessen bestimmter Wert das Maximum aller bestimmter Werte ist.
        /// </summary>
        /// <typeparam name="TResult">Der Typ der Elemente in der Quellauflistung.</typeparam>
        /// <typeparam name="TComparable">Der Typ der zum Größenvergleich der Werte dient.</typeparam>
        /// <param name="source">Die Quellliste mit den Elementen.</param>
        /// <param name="predicate">Eine Funktion zum auswählen des bestimmten Wertes eines Elements.</param>
        /// <returns>Das Element aus <paramref name="source"/> dessen mit <paramref name="predicate"/> bestimmter Wert Maximal ist.</returns>
        /// <exception cref="System.ArgumentNullException">Wird ausgelöst, wenn einer der Parameter <c>null</c> ist.</exception>
        /// <exception cref="System.InvalidOperationException">Wird ausgelöst, wenn <paramref name="source"/> 
        /// kein Element enthält oder aber mehr als eines, dessen Wert maximal ist.</exception>
        public static TResult SingleMax<TResult, TComparable>(this IEnumerable<TResult> source, Func<TResult, TComparable> predicate)
            where TComparable : IComparable<TComparable>
        {
            return SelectMinMax(source, predicate, -1);
        }

        private static TResult SelectMinMax<TResult, TComparable>(IEnumerable<TResult> source, Func<TResult, TComparable> predicate, int compareToResult)
            where TComparable : IComparable<TComparable>
        {
            Argument.IsNotNull(() => source);
            Argument.IsNotNull(() => predicate);
            var item = source.FirstOrDefault();
            if (item == null)
            {
                throw new InvalidOperationException("The Sequence is empty");
            }
            var key = predicate(item);
            bool foundMultipleOccurences = false;
            foreach (var inner in source.Skip(1))
            {
                var innerKey = predicate(inner);
                var compareResult = key.CompareTo(innerKey);
                if (compareResult == compareToResult)
                {
                    item = inner;
                    key = innerKey;
                    foundMultipleOccurences = false;
                }
                else if (compareResult == 0)
                {
                    foundMultipleOccurences = true;
                }
            }
            if (foundMultipleOccurences)
            {
                throw new InvalidOperationException("The Sequence contain more than one matching elements.");
            }
            return item;
        }

        /// <summary>
        /// Wählt alle Elemente aus der Quellauslistung aus, die nicht einem 
        /// bestimmten Typ oder einer Ableitung dessen entsprechen.
        /// </summary>
        /// <typeparam name="TRemove">Der Typ der nicht mit aufgelistet werden soll.</typeparam>
        /// <param name="source">Die Quellauflistung.</param>
        /// <returns>Eine Auflistung mit allen Elementen von <paramref name="source"/>
        /// die nicht <typeparamref name="TRemove"/> als Typ oder Basis-Typ haben.</returns>
        public static IEnumerable NotOfType<TRemove>(this IEnumerable source)
        {
            Argument.IsNotNull(() => source);
            foreach (var item in source)
            {
                if (!(item is TRemove))
                {
                    yield return item;
                }
            }
        }
    }
}
