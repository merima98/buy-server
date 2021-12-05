using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        public Guid CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
