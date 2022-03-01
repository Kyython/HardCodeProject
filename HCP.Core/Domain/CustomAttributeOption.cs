using System;

namespace HCP.Core.Domain
{
    public class CustomAttributeOption : BaseEntity
    {
        public string Name { get; set; }

        public Guid CustomAttributeId { get; set; }

        public virtual CustomAttribute CustomAttribute { get; set; }
    }
}
