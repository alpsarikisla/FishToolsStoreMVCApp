using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class OrderController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: Order
        public ActionResult Index()
        {
            List<ShoppingCart> cart = Session["Cart"] as List<ShoppingCart>;

            if (cart != null && cart.Any())
            {
                ViewBag.Cart = cart;
                return View();
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
       
    }
}