using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Models
{
    public class SystemHelpers
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        public int getProductCount(int? memberId)
        {
            int count = 0;
            if (memberId != null)
            {
                int id = Convert.ToInt32(memberId);
                count = db.ShoppingCarts.Count(s => s.Member_ID == id);
            }
            return count;
        }
    }
}