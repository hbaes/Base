using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTimeOffset Created { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset LastModified { get; private set; } = DateTimeOffset.UtcNow;

        public void UpdateLastModified()
        {
            LastModified = DateTimeOffset.UtcNow;
        }
    }
}
