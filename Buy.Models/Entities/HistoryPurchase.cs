using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class HistoryPurchase
    {
        public HistoryPurchase()
        {
            SoldProducts = new HashSet<SoldProduct>();
        }

        public Guid HistoryPurchaseId { get; set; }
        public decimal TotalPriceOfPurchase { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
