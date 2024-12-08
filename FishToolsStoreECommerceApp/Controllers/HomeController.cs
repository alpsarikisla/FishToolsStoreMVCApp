using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.categories = db.Categories.Where(p => p.IsDeleted == false && p.IsActive == true).ToList();
            return View(db.Products.Where(p=> p.IsDeleted==false && p.IsActive == true).ToList());
        }
    }
}