using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FishToolsStoreECommerceApp.Models
{
    public class Favorite
    {
        public int ID { get; set; }

        public int Product_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        public int Member_ID { get; set; }

        [ForeignKey("Member_ID")]
        public virtual Member Member { get; set; }
    }
}