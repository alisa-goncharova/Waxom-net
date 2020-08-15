using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopSite shopSite;
        public OrderController(IAllOrders allOrders, ShopSite shopSite)
        {
            this.allOrders = allOrders;
            this.shopSite = shopSite;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order){

            shopSite.listShopItems = shopSite.getShopItems();

            if (shopSite.listShopItems.Count == 0) {
                ModelState.AddModelError("","У вас должны быть товары");
            }
            if (ModelState.IsValid) 
            {
                allOrders.createOrder(order);
                shopSite.ClearShopitems();
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete() 
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
