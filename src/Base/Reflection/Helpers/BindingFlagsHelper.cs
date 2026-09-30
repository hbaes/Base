namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Diagnostics;

    /// <summary>
    /// Helper class for BindingFlags
    /// </summary>
    public static class BindingFlagsHelper
    {

#if NET
        /// <summary>
        /// The default binding flags.
        /// </summary>
        public const System.Reflection.BindingFlags DefaultBindingFlags =
                                                        System.Reflection.BindingFlags.Instance |
                                                        System.Reflection.BindingFlags.Public |
                                                        System.Reflection.BindingFlags.NonPublic;
#else
		/// <summary>
		/// The default binding flags.
		/// </summary>
		public const BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Public;
#endif

        /// <summary>
        /// Gets final binding flags and respects the <see cref="DefaultBindingFlags" /> as defined in Catel.
        /// </summary>
        /// <param name="flattenHierarchy">A value representing whether the hierarchy should be flattened. Corresponds with <see cref="System.Reflection.BindingFlags.FlattenHierarchy" />.</param>
        /// <param name="allowStaticMembers">A value representing whether static members should be included. Corresponds with <see cref="System.Reflection.BindingFlags.Static" />.</param>
        /// <param name="allowNonPublicMembers">A value representing whether non-public members should be included. Corresponds with 
        /// <see cref="System.Reflection.BindingFlags.NonPublic" />.
        /// <para />
        /// If this value is 
        /// <c>null</c>, the default of the framework will be used. Also see 
        /// <see cref="DefaultBindingFlags" />.</param>
        /// <returns>
        /// The final binding flags.
        /// </returns>
        [DebuggerStepThrough]
        public static System.Reflection.BindingFlags GetFinalBindingFlags(
            bool flattenHierarchy,
            bool allowStaticMembers,
            bool? allowNonPublicMembers = null)
        {
            System.Reflection.BindingFlags mybindingFlags = DefaultBindingFlags;

            if (allowNonPublicMembers.HasValue)
            {
                if (allowNonPublicMembers.Value)
                {
                    mybindingFlags = Enum<System.Reflection.BindingFlags>.Flags.SetFlag(mybindingFlags, System.Reflection.BindingFlags.NonPublic);
                }
                else
                {
                    mybindingFlags = Enum<System.Reflection.BindingFlags>.Flags.ClearFlag(mybindingFlags, System.Reflection.BindingFlags.NonPublic);
                }
            }

            if (flattenHierarchy)
            {
                mybindingFlags = Enum<System.Reflection.BindingFlags>.Flags.SetFlag(mybindingFlags, System.Reflection.BindingFlags.FlattenHierarchy);
            }

            if (allowStaticMembers)
            {
                mybindingFlags = Enum<System.Reflection.BindingFlags>.Flags.SetFlag(mybindingFlags, System.Reflection.BindingFlags.Static);
            }

            return mybindingFlags;
        }




    }
}
