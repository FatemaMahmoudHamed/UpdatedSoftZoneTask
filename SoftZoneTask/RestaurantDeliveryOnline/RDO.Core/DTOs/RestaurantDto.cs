using RDO.Core.Entities;
using System;
using System.Collections.Generic;

namespace RDO.Core.Dtos
{
    /// <summary>
    /// Restaurant to display the user in a list.
    /// </summary>
    public class RestaurantListItemDto
    {

    }

    /// <summary>
    /// Restaurant to display the user information in the details view.
    /// </summary>
    public class RestaurantDetailsDto
    {
    }

    /// <summary>
    /// Restaurant to create or edit user.
    /// </summary>
    public class RestaurantDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public string Image { get; set; }

        public ICollection<Product> Menu { get; set; } = new List<Product>();
    }

}