using FishToolsStoreECommerceApp.Areas.ManagerPanel.Filters;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class OrderDetailController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: ManagerPanel/OrderDetail
        public ActionResult Index()
        {
            return View(db.OrderDetail.ToList());
        }
    }
}