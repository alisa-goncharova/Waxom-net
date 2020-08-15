using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        [BindNever]
        public int id{get;set;}

        [Display (Name="Введите имя")]
        [StringLength(15)]
        [Required(ErrorMessage ="Длина имени не более 15 символов")]
        public string name { get; set; }


        [Display(Name = "Введите фамилию")]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина фамилии не более 30 символов")]
        public string surname { get; set; }


        [Display(Name = "Введите адресс")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина адреса не более 50 символов")]
        public string adress { get; set; }



        [Display(Name = "Введите номер")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера не более 20 символов")]
        public string phone { get; set; }



        [Display(Name = "Введите e-mail")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина e-mail не более 30 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


    }
}
