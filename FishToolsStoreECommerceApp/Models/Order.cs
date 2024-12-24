using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Models
{
    public class Order
    {
        public Order()
        {
            IsActive = true;
            IsDeleted = false;
        }

        public int OrderID { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Üye ID")]
        public string MemberID { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Teslimat Tarihi")]
        [DataType(DataType.Date)]
        public DateTime RequiredDate { get; set; }

        [Display(Name = "Kargolama Tarihi")]
        [DataType(DataType.Date)]
        public DateTime ShippedDate { get; set; }

        [Display(Name = "Kargo Ücreti")]
        public decimal Freight { get; set; }

        [Display(Name = "Teslimat İsmi")]
        public string ShipName { get; set; }

        [Display(Name = "Teslimat Adresi")]
        public string ShipAddress { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}