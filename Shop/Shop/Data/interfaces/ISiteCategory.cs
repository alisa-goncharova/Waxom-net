using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.interfaces
{
    public interface ISiteCategory // функция которая возвращает все категории из модели Category
    { 
        IEnumerable<Category> AllCategories { get; }
    }
}
