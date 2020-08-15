using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewsModels
{
    public class SitesLastViewModel // функци которая получает все товары
    {
        public IEnumerable<Site> allSites{ get; set; }

        public string sittCategory { get; set; }
    }
}
