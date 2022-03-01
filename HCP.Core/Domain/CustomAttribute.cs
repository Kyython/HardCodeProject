using System;

namespace HCP.Core.Domain
{
    public class CustomAttribute : BaseEntity
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
