using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Products = new HashSet<Product>();
            SoldProducts = new HashSet<SoldProduct>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImageUrl { get; set; }
        public int Gender { get; set; }
        public Guid CityId { get; set; }
        public int RoleType { get; set; }
        public Guid CartId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
