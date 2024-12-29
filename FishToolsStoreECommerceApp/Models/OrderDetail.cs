using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Models
{
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Sipariş ID")]
        public int Order_ID { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Ürün ID")]
        public int Product_ID { get; set; }

        [Display(Name = "Fiyat")]
        public double UnitPrice { get; set; }

        [Display(Name = "Adet")]
        public int Quantity { get; set; }

        [Display(Name = "İndirim")]
        public int Discount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}