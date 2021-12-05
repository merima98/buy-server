using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class ProductOnCart
    {
        public Guid ProductOnCart1 { get; set; }
        public DateTime DateOfAddingToCart { get; set; }
        public int Quantity { get; set; }
        public int ProductPrice { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
