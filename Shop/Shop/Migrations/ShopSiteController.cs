using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Repository;
using Shop.Models;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopSiteController: Controller
    {
        private readonly IAllSites _sitRep;
        private readonly ShopSite _shopSite;

        public ShopSiteController(IAllSites sitRep, ShopSite shopSite) {
            _sitRep = sitRep;
            _shopSite = shopSite;
        }

        public ViewResult Index() 
        {
            var items = _shopSite.getShopItems();
            _shopSite.listShopItems = items;


            var obj = new ShopSiteViewModel
            {
                shopSite = _shopSite
            };

            return View(obj);
        }
        public RedirectToActionResult addToSite(int id) 
        {
            var item = _sitRep.Sites.FirstOrDefault(i=>i.id == id);
            if (item!=null) {
                _shopSite.AddToSite(item);
            }
            return RedirectToAction("index");
        }
        public RedirectToActionResult Delete(int id) 
        {
                _shopSite.DeleteShopItem(id);
                return RedirectToAction("index");
        }
    }
}
