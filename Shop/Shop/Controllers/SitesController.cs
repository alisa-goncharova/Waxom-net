using Microsoft.AspNetCore.Mvc;
//using Shop.Models;
using Shop.Data.interfaces;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class SitesController : Controller // функции при которых возвращается результат виде html страницы, данная функция возвращает html страницу
    {
        private readonly IAllSites _allSites;
        private readonly ISiteCategory _allCategories;
        private object SitesListViewModel;

        public SitesController(IAllSites iAllSites, ISiteCategory iSitesCat)
        {
            _allSites = iAllSites;
            _allCategories = iSitesCat;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с сайтами";
            SitesLastViewModel obj = new SitesLastViewModel();
            obj.allSites = _allSites.Sites;
            obj.sittCategory = "Сайты";
            return View(obj);
        }
    }
}
