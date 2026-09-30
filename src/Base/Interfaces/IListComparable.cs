namespace Base.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface describing a Comparable List
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
    public interface IListComparable
    {
        /// <summary>
        /// ID member to compare to instances if they are the same ..
        /// </summary>
        string ID { get; set; }
    }
}
