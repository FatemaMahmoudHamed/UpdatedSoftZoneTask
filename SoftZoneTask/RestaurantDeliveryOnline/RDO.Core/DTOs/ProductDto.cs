using System;
using System.Collections.Generic;

namespace RDO.Core.Dtos
{
    /// <summary>
    /// Product to display the user in a list.
    /// </summary>
    public class ProductListItemDto
    {

    }

    /// <summary>
    /// Product to display the user information in the details view.
    /// </summary>
    public class ProductDetailsDto
    {
    }

    /// <summary>
    /// Product to create or edit user.
    /// </summary>
    public class ProductDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }

}