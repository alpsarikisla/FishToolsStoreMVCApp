using FishToolsStoreECommerceApp.Data.ViewModels;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class CheckoutController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();

        // GET: Checkout
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Months = new SelectList(Enumerable.Range(1, 12));
            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Now.Year, 20));

            return View();
        }

        [HttpPost]
        public ActionResult Payment(PaymentViewModel model)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            int id = ((Member)Session["user"]).ID;
            List<ShoppingCart> cart = db.ShoppingCarts.Where(x => x.Member_ID == id).ToList();

            if (!ModelState.IsValid)
            {
                TempData["cart"] = cart;
                ViewBag.Months = new SelectList(Enumerable.Range(1, 12));
                ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Now.Year, 20));

                return View("Index", model);
            }
            else
            {
                foreach (ShoppingCart item in cart)
                {
                    db.ShoppingCarts.Remove(item);
                }

                db.SaveChanges();

                return RedirectToAction("Index", "ShoppingCart");
            }
        }
    }
}