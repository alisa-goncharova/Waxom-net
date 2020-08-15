using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObject
    {
        public static void Initial(AppDBContent content) 
        {
            
                
            if (!content.Category.Any()) 
            {
                content.Category.AddRange(Categories.Select(c => c.Value)); // создание списков объектов и проверка на не отсутствие категории
            }
            if (!content.Site.Any()) 
            {
                content.AddRange(
                    new Site
                    {
                        name = "Сайт-Визитка",
                        shortDesc = "Персональный сайт визитка",
                        longDesc = "",
                        img = "/img/site-vizitka.png",
                        price = 100,
                        isFavorite = true,
                        available = true,
                        category = Categories["Легкий"]
                    },
                    new Site
                    {
                        name = "Лэндинг",
                        shortDesc = "Одностраничный сайт",
                        longDesc = "",
                        img = "/img/site-landing.png",
                        price = 100,
                        isFavorite = true,
                        available = true,
                        category = Categories["Легкий"]

                    },
                    new Site
                    {
                        name = "Корпоротивный сайт",
                        shortDesc = "Корпоротивный сайт или сайт с каталогом",
                        longDesc = "",
                        img = "/img/site-mobile.png",
                        price = 600,
                        isFavorite = true,
                        available = true,
                        category = Categories["Сложный"]

                    },

                    new Site
                    {
                        name = "Интернет-магазин",
                        shortDesc = "Интернет-магазин под ключ",
                        longDesc = "",
                        img = "/img/site-vizitka.png",
                        price = 200,
                        isFavorite = true,
                        available = true,
                        category = Categories["Сложный"]
                    },
                    new Site
                    {
                        name = "Дороботка",
                        shortDesc = "Дороботка и сопровождение вашего сайта",
                        img = "/img/site-service.png",
                        longDesc = "",
                        price = 100,
                        isFavorite = true,
                        available = true,
                        category = Categories["Легкий"]

                    },
                    new Site
                    {
                        name = "Макет",
                        shortDesc = "Верстка сайта по макетам заказчика",
                        longDesc = "",
                        img = "/img/site-verstka.png",
                        price = 100,
                        isFavorite = true,
                        available = true,
                        category = Categories["Легкий"]

                    },
                    new Site
                    {
                        name = "Оптимизация",
                        shortDesc = "Оптимизация сайта под мобильные устройства",
                        longDesc = "",
                        img = "/img/site-mobile.png",
                        price = 100,
                        isFavorite = true,
                        available = true,
                        category = Categories["Сложный"]

                    }
                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories 
        {
            get
            {
                if (category == null) // проверка заполнена ли переменная категория, если есть объектывернуть, если пустая, то создается новый список категории, далее создается выделение помяти под переменную 
                {
                    var list = new Category[]
                    {
                new Category{ categoryName = "Легкий", desc = "напр Персональный сайт визитка"},
                new Category{ categoryName = "Сложный", desc = "напр Персональный сайт для интернет магазина"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }
                return category;
            }
        }
    }
 }

