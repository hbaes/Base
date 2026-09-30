using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.EFCore.Extensions
{
    public static partial class PropertyBuilderExtensions
    {
        public static PropertyBuilder<T> IsReadOnly<T>(this PropertyBuilder<T> prop, bool readOnly = true)
        {
            ArgumentNullException.ThrowIfNull(prop, nameof(prop));
            prop.Metadata.SetAfterSaveBehavior(readOnly ? PropertySaveBehavior.Throw : PropertySaveBehavior.Save);
            return prop;
        }
    }
}
