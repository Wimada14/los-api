using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace los_api.Model
{
    public class ProductModel
    {
        public int id { get; set; }
        public String name { get; set; }
        public String imageUrl { get; set; }
        public int price { get; set; }
    }
}
