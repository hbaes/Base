using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Base.Network
{
    /// <summary>
    /// MAC utils
    /// </summary>
    public static class MACUtility
    {
        /// <summary>
        /// Determines whether [is mac address valid] [the specified input mac address].
        /// </summary>
        /// <param name="inputMACAddress">The input mac address.</param>
        /// <returns>
        ///   <c>true</c> if [is mac address valid] [the specified input mac address]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMACAddressValid(string inputMACAddress)
        {
            Regex MACAddressRegex = new Regex(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
            Match match = MACAddressRegex.Match(inputMACAddress);

            return match.Success;
        }
    }
}
