using System;

namespace HCP.Core.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
