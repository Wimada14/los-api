using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace los_api.Model
{
    public class StockModel
    {
        public String id { get; set; }
        public String productId { get; set; }
        public int amount { get; set; }
    }
}
