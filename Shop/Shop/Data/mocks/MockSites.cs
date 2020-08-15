using Shop.Data.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockSites : IAllSites
    {
        private readonly ISiteCategory _categorySites = new MockCategory();
        public IEnumerable<Site> Sites
        {

            get
            {
                return new List<Site>
                {
                    new Site {
                        name = "Сайт-Визитка",
                        shortDesc = "Персональный сайт визитка",
                        longDesc = "",
                        img = "/img/site-vizitka.png",
                        price= 100,
                        isFavorite = true,
                        available = true,
                        category = _categorySites.AllCategories.First()
                    },
                    new Site {
                    name = "Лэндинг",
                    shortDesc = "Одностраничный сайт",
                    longDesc = "",
                    img = "/img/site-landing.png",
                    price = 100,
                    isFavorite = true,
                    available = true,
                    category = _categorySites.AllCategories.First()

                    },
                    new Site {
                    name = "Корпоротивный сайт",
                    shortDesc = "Корпоротивный сайт или сайт с каталогом",
                    longDesc = "",
                    img = "/img/site-korporat.png",
                    price = 600,
                    isFavorite = true,
                    available = true,
                    category = _categorySites.AllCategories.First()

                    },

                    new Site {
                        name = "Интернет-магазин",
                        shortDesc = "Интернет-магазин под ключ",
                        longDesc = "",
                        img = "/img/site-magazin.png",
                        price= 200,
                        isFavorite = true,
                        available = true,
                        category = _categorySites.AllCategories.Last()
                    },
                    new Site {
                    name = "Дороботка",
                    shortDesc = "Дороботка и сопровождение вашего сайта",
                    img = "/img/site-service.png",
                    longDesc = "",
                    price = 100,
                    isFavorite = true,
                    available = true,
                    category = _categorySites.AllCategories.First()

                    },
                    new Site {
                    name = "Макет",
                    shortDesc = "Верстка сайта по макетам заказчика",
                    longDesc = "",
                    img = "/img/site-verstka.png",
                    price = 100,
                    isFavorite = true,
                    available = true,
                    category = _categorySites.AllCategories.First()

                    },
                    new Site {
                    name = "Оптимизация",
                    shortDesc = "Оптимизация сайта под мобильные устройства",
                    longDesc = "",
                    img = "/img/site-mobile.png",
                    price = 100,
                    isFavorite = true,
                    available = true,
                    category = _categorySites.AllCategories.First()

                    }

                };
            }
        }
        public IEnumerable<Site> getFavSites { get; set; }

        public Site getObjectSite(int siteID)
        {
            throw new NotImplementedException();
        }
    }
}
