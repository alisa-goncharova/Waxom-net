using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShopSitesItem
    {
        public int id { get; set; }
        public Site site { get; set; }
        public int price { get; set; }
        public string ShopSitesId { get; set; }
    }
}
