using System.Collections.Generic;

namespace HCP.Core.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<CustomAttribute> CustomAttributes { get; set; }
    }
}
