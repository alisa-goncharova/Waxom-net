using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Site
    {
        public int id { set; get; } //id товара
        public string name { set; get; } //имя
        public string shortDesc { set; get; } //короткое описание
        public string longDesc { set; get; } //длинное описание
        public string img { set; get; } //картинка
        public ushort price { set; get; } //цена
        public bool isFavorite { set; get; } //выбранное
        public bool available { set; get; }
        public int categoryID { set; get; }
        public virtual Category category { set; get; }
    }
}
