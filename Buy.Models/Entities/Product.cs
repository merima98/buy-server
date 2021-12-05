using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductOnCarts = new HashSet<ProductOnCart>();
            SoldProducts = new HashSet<SoldProduct>();
        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ShippingPrice { get; set; }
        public bool ShippingFree { get; set; }
        public DateTime DateOfPublication { get; set; }
        public DateTime DateOfModification { get; set; }
        public int DeliveryTime { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int TotalAvailableProducts { get; set; }
        public int Gender { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ConditionId { get; set; }
        public Guid CreatorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<ProductOnCart> ProductOnCarts { get; set; }
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
