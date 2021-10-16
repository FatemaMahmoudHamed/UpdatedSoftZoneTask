using System;

namespace RDO.Infrastructure.Entities
{
    public class QueryObject
    {
        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }

    public class RestaurantQueryObject : QueryObject
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string SearchText { get; set; }
    }
    public class ProductQueryObject : QueryObject
    {
        public int RestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
    }
    public class OrderQueryObject : QueryObject
    {
    }



}