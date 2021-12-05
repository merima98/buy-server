using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class SoldProduct
    {
        public Guid SoldProductId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal PriceOfProduct { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool Sold { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPriceOfProduct { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public Guid HistoryPurchaseId { get; set; }

        public virtual HistoryPurchase HistoryPurchase { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
