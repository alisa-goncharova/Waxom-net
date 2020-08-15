using Shop.Models;
using Shop.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCategory : ISiteCategory
    {
        public IEnumerable<Category> AllCategories //функция которая возвращает все катогрии
        {
            get
            {
                return new List<Category>
                {
                    new Category{ categoryName = "Легкий", desc = "напр Персональный сайт визитка"},
                    new Category{ categoryName = "Сложный", desc = "напр Персональный сайт для интернет магазина"}
                };
            }

        }
    }
}
