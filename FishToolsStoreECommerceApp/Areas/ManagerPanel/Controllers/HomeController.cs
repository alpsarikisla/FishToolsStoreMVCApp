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
    public class HomeController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: ManagerPanel/Home
        public ActionResult Index()
        {
            ViewBag.ProductCount = db.Products.Where(x=> x.IsDeleted==false).Count();
            ViewBag.CategoryCount = db.Categories.Where(x => x.IsDeleted == false).Count();
            ViewBag.BrandCount = db.Brands.Where(x => x.IsDeleted == false).Count();
            ViewBag.MemberCount = db.Members.Where(x => x.IsDeleted == false).Count();
            return View();
        }
    }
}