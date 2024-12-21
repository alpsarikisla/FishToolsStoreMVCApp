using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                int id = (Session["user"] as Member).ID;
                return View(db.ShoppingCarts.Where(s => s.Member_ID == id).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult AddToCart(int id)
        {
            if (Session["user"] != null)
            {
                ShoppingCart sc = new ShoppingCart();
                sc.Member_ID = (Session["user"] as Member).ID;
                sc.Product_ID = id;
                sc.Quantity = 1;
                db.ShoppingCarts.Add(sc);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "ShoppingCart");
        }
        public ActionResult DeleteFromCart(int id)
        {
            if (Session["user"] != null)
            {
                ShoppingCart sc = db.ShoppingCarts.Find(id);
                db.ShoppingCarts.Remove(sc);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "ShoppingCart");
        }


    }
}