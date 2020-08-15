using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShopSite
    {
        private readonly AppDBContent appDBContent;
        public ShopSite(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopSiteId { get; set; }
        public List<ShopSitesItem> listShopItems { get; set; }
        public static ShopSite GetSite(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopSiteId = session.GetString("SiteId") ?? Guid.NewGuid().ToString();
            
            session.SetString("SiteId", shopSiteId);

            return new ShopSite(context) { ShopSiteId = shopSiteId};

        }

        public void AddToSite(Site site) {
            appDBContent.ShopSitesItem.Add(new ShopSitesItem
            {
                ShopSitesId = ShopSiteId,
                site = site,
                price = site.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopSitesItem> getShopItems() 
        {
            return appDBContent.ShopSitesItem.Where(c => c.ShopSitesId == ShopSiteId).Include(s => s.site).ToList();
        }
        public void ClearShopitems() 
        {
            appDBContent.ShopSitesItem.RemoveRange(appDBContent.ShopSitesItem.Where(c => c.ShopSitesId == ShopSiteId));
            appDBContent.SaveChanges();
        }
        public void DeleteShopItem(int id) 
        {
  
            appDBContent.ShopSitesItem.Remove(appDBContent.ShopSitesItem.Find(id));
            appDBContent.SaveChanges();
        }
    }
}
