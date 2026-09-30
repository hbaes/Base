using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.EFCore.Extensions
{
    public static partial class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<T> IsReadOnly<T>(this EntityTypeBuilder<T> builder) where T : class
        {
            ArgumentNullException.ThrowIfNull(builder, nameof(builder));
            var metadata = builder.Metadata;
            var tableName = metadata.GetAnnotation(RelationalAnnotationNames.TableName).Value;
            //var tableSchema = metadata.GetAnnotation(RelationalAnnotationNames.Schema).Value;
            metadata.RemoveAnnotation(RelationalAnnotationNames.TableName);
            metadata.RemoveAnnotation(RelationalAnnotationNames.Schema);
            metadata.SetAnnotation(RelationalAnnotationNames.ViewName, tableName);
            //metadata.SetAnnotation(RelationalAnnotationNames.ViewSchema, tableSchema);
            return builder;
        }
    }
}
