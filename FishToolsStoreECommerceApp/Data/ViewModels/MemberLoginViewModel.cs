using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Data.ViewModels
{
    public class MemberLoginViewModel
    {

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail alanı zorunludur")]
        [StringLength(maximumLength:254,ErrorMessage = "Mail alanı en fazla 254 karakter olabilir")]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [StringLength(maximumLength: 20, ErrorMessage = "Şifre alanı en fazla 20 karakter olabilir")]
        public string Password { get; set; }
    }
}