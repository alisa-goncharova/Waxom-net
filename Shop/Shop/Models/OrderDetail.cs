using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderDetail
    {
        public int id{ get; set; }
        public int orderID { get; set; }
        public int SiteID { get; set; }
        public uint price { get; set; }
        public virtual Site site { get; set; }
        public virtual Order order { get; set; }
        
    }
}
