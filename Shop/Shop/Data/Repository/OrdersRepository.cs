using Shop.Data.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository: IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopSite shopSite;
        public OrdersRepository(AppDBContent appDBContent, ShopSite shopSite) 
        {
            this.appDBContent = appDBContent;
            this.shopSite = shopSite;
        }

        public void createOrder(Order order) {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopSite.listShopItems; // все товары которые доб пользователь

            foreach(var el in items) 
            {
                var orderDetail = new OrderDetail() {
                    SiteID = el.site.id,
                    orderID = order.id,
                    price = el.site.price
                };
                appDBContent.OrderDetail.Add(orderDetail);

            }
            appDBContent.SaveChanges();
        }
    }
}
