using RDO.Core.Entities;
using System;
using System.Collections.Generic;

namespace RDO.Core.Dtos
{
    /// <summary>
    /// Order to display the user in a list.
    /// </summary>
    public class OrderListItemDto
    {

    }

    /// <summary>
    /// Order to display the user information in the details view.
    /// </summary>
    public class OrderDetailsDto
    {
    }

    /// <summary>
    /// Order to create or edit user.
    /// </summary>
    public class OrderDto
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderProductDto> OrderProducts { get; set; } = new List<OrderProductDto>();
        public decimal TotalPrice { get; set; }
        public CustomerDto Customer { get; set; }

    }

}