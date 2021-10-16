using RDO.Core.Entities;
using System;
using System.Collections.Generic;

namespace RDO.Core.Dtos
{
    /// <summary>
    /// Customer to display the user in a list.
    /// </summary>
    public class CustomerListItemDto
    {

    }

    /// <summary>
    /// Customer to display the user information in the details view.
    /// </summary>
    public class CustomerDetailsDto
    {
    }

    /// <summary>
    /// Customer to create or edit user.
    /// </summary>
    public class CustomerDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }

}