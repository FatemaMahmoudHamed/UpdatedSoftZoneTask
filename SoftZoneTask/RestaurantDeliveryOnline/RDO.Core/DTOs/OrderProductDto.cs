using RDO.Core.Entities;
using System;
using System.Collections.Generic;

namespace RDO.Core.Dtos
{
    /// <summary>
    /// OrderProduct to display the user in a list.
    /// </summary>
    public class OrderProductListItemDto
    {

    }

    /// <summary>
    /// OrderProduct to display the user information in the details view.
    /// </summary>
    public class OrderProductDetailsDto
    {
    }

    /// <summary>
    /// OrderProduct to create or edit user.
    /// </summary>
    public class OrderProductDto 
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

}