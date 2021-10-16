using System;
using System.Collections.Generic;

namespace RDO.Core.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public Product Product { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
