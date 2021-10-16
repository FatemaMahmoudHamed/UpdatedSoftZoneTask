using System;
using System.Collections.Generic;

namespace RDO.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int RestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
