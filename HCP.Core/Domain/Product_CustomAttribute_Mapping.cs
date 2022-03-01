using System;

namespace HCP.Core.Domain
{
    public class Product_CustomAttribute_Mapping : BaseEntity
    {
        public Guid CustomAttributeOptionId { get; set; }

        public virtual CustomAttributeOption CustomAttributeOption { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}