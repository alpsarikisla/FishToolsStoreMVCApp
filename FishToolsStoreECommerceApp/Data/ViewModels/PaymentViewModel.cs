using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Data.ViewModels
{
    public class PaymentViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad giriniz.")]
        public string FullName { get; set; }

        [Display(Name = "Kart Numarası")]
        [Required(ErrorMessage = "Kart numarasını giriniz.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Kart numarası 16 haneli olmalıdır.")]
        public string CardNumber { get; set; }

        [Display(Name = "Ay")]
        [Required(ErrorMessage = "Son kullanma ayını seçiniz.")]
        public int ExpirationMonth { get; set; }

        [Display(Name = "Yıl")]
        [Required(ErrorMessage = "Son kullanma yılını seçiniz.")]
        public int ExpirationYear { get; set; }

        [Display(Name = "CVV")]
        [Required(ErrorMessage = "CVC kodu giriniz.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVC kodu 3 haneli olmalıdır.")]
        public string CVV { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Adres giriniz.")]
        public string Address { get; set; }

        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "Şehir giriniz.")]
        public string City { get; set; }

        [Display(Name = "Posta Kodu")]
        [Required(ErrorMessage = "Posta kodu giriniz.")]
        public string PostalCode { get; set; }
    }
}