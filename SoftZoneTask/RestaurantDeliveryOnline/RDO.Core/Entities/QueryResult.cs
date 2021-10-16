using System.Collections.Generic;

namespace RDO.Core.Entities
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
