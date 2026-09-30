
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.LDAP
{
    public static class LDAPExtensions
    {
        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="sr">The sr.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static string GetPropertyValue(this SearchResult sr, string propertyName)
        {
            string ret = string.Empty;

            if (sr.Properties[propertyName].Count > 0)
                ret = sr.Properties[propertyName][0].ToString();

            return ret;
        }
    }
}
