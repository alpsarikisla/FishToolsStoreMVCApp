using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Models
{
    public class Category
    {
        public Category()
        {
            IsActive = true; IsDeleted = false;
        }

        //ID ismi verdiğimiz kolon otomatik olarak PRIMARY KEY VE IDENTITY(1,1) özelliğine sahip olur
        public int ID { get; set; }

        [Display(Name="Kategori Adı")]
        //Required attribute'u kolonu veritabanında NOT NULL Yapar
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength:150, ErrorMessage ="En fazla 150 karakter olabilir")]//kolon nvarchar(150) oldu
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]//View Alanında text area oluşturur
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olabilir")]
        public string Description { get; set; }

        [Display(Name="Durum")]
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}