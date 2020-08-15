using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Category
    {
        public int id { set; get; } //id
        public string categoryName { set; get; } // имя категории
        public string desc { set; get; } //описание категории
        public List<Site> site { set; get; }
    }
}
