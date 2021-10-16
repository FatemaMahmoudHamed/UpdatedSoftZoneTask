using System;
using System.Collections.Generic;

namespace RDO.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Customer Customer { get; set; }

    }
}
