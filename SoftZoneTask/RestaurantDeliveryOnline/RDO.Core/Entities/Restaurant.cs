using System;
using System.Collections.Generic;

namespace RDO.Core.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public string Image { get; set; }

        public ICollection<Product> Menu { get; set; } = new List<Product>();

    }
}
