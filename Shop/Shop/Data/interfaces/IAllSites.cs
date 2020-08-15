using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.interfaces
{
    public interface IAllSites // функция которая возвращает все товары, функция которая возвращает лишь избранные товары(IsFavorite == true), функция которая возвращает конкретный товар по его id
    {
        IEnumerable<Site> Sites { get; }
        IEnumerable<Site> getFavSites { get; }
        Site getObjectSite(int siteId);
    }
}
