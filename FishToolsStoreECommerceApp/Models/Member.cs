using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Models
{
    public class Member
    {
        public Member()
        {
            CreationTime = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
            LastLoginTime = DateTime.Now;
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "İsim")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Soyisim")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "E-Posta")]
        [StringLength(maximumLength: 150, ErrorMessage = "Bu alan en fazla 150 karakter olabilir")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Şifre")]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Bu alan 6 - 20 karakter olabilir")]
        public string Password { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }

        [Display(Name = "Son Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastLoginTime { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}