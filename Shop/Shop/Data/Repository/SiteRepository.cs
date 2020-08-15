using Microsoft.EntityFrameworkCore;
using Shop.Data.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class SiteRepository : IAllSites
    {
        private readonly AppDBContent appDBContent;
        public SiteRepository(AppDBContent appDBContent) 
        {
            this.appDBContent = appDBContent;
        }


        public IEnumerable<Site> Sites => appDBContent.Site.Include(c =>c.category); // получениевсех объектов

        public IEnumerable<Site> getFavSites => appDBContent.Site.Where(p => p.isFavorite).Include(c => c.category);  // получение выбранныхобъектов

        public Site getObjectSite(int siteId) => appDBContent.Site.FirstOrDefault(p => p.id == siteId); // один объект
        
    }
}
