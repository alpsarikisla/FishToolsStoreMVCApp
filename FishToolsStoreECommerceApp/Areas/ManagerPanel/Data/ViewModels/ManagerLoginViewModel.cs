using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Data.ViewModels
{
    public class ManagerLoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Mail alanı zorunludur")]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        public string Password { get; set; }
    }
}