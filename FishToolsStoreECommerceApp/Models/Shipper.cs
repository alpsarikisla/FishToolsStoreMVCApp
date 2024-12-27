using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Models
{
    public class Shipper
    {
        public int ID { get; set; }

        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Display(Name = "İletişim Numarası")]
        public string Contact { get; set; }
    }
}