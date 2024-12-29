using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Models
{
    public class Order
    {
        public Order()
        {
            IsCancelled = false;
        }

        [Key]
        public int Order_ID { get; set; }

        [Display(Name = "Üye ID")]
        public int? Member_ID { get; set; }

        [Display(Name = "Alıcı")]
        [ForeignKey("Member_ID")]
        public virtual Member Member { get; set; }

        [Display(Name = "Kargo ID")]
        public int? Shipper_ID { get; set; }

        [Display(Name = "Kargo")]
        [ForeignKey("Shipper_ID")]
        public virtual Shipper Shipper { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Teslimat Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Kargolanma Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ShippedDate { get; set; }

        [Display(Name = "Kargo Ücreti")]
        public double ShippingFee { get; set; }

        [Display(Name = "Teslimat Adresi")]
        public string ShippingAdress { get; set; }

        //Belki sipariş iptali için kullanırım ama uğraşırmıyım bilmiyorum.
        public bool IsCancelled { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}