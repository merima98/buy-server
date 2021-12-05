using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            ProductOnCarts = new HashSet<ProductOnCart>();
            Users = new HashSet<User>();
        }

        public Guid CartId { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<ProductOnCart> ProductOnCarts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
