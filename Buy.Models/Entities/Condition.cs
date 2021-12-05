using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class Condition
    {
        public Condition()
        {
            Products = new HashSet<Product>();
        }

        public Guid ConditionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
