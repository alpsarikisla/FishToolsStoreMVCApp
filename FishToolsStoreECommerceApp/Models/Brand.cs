using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Models
{
    public class Brand
    {
        public Brand() { IsActive = true; IsDeleted = false; }

        public int ID { get; set; }

        [Display(Name = "Marka Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 150, ErrorMessage = "En fazla 150 karakter olabilir")]
        public string Name { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}