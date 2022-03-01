using System;

namespace HCP.Core.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
