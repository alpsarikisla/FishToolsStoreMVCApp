using FishToolsStoreECommerceApp.Areas.ManagerPanel.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class HomeController : Controller
    {
        // GET: ManagerPanel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}