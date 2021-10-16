﻿using System.Collections.Generic;

namespace RDO.Core.Dtos
{
    public class QueryResultDto<T>
    {
        public int TotalItems { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
