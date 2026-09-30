namespace Base.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface describing return value of a custom class.
    /// If a class implements this interface the LogReturnValue will be used
    /// to log the return value inisde the debug.log
    /// </summary>
    public interface ILogReturnValue
    {
        /// <summary>
        /// Logs the return value.
        /// </summary>
        /// <returns></returns>
        string LogReturnValue();
    }
}
