using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

                List<ShoppingCart> cart = db.ShoppingCarts
                                        .Where(s => s.Member_ID == id)
                                        .Include(s => s.Product)
                                        .ToList();

                return View(cart);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult AddToCart(int id, int quantity)
        {
            if (Session["user"] != null)
            {
                int memberId = (Session["user"] as Member).ID;

                Product product = db.Products.Find(id); 
                if (product == null || product.Stock < quantity) 
                {
                    ViewBag.Error = $"Üzgünüz, '{product?.Name}' ürünü için yeterli stok yok.";
                    return View("Index", db.ShoppingCarts.Where(s => s.Member_ID == memberId).Include(s => s.Product).ToList());
                }

                ShoppingCart cart = db.ShoppingCarts.FirstOrDefault(s => s.Member_ID == memberId && s.Product_ID == id);

                if (cart != null)
                {
                    if (product.Stock < cart.Quantity + quantity)
                    {
                        ViewBag.Error = $"Üzgünüz, '{product.Name}' ürünü için bu kadar stok mevcut değil.";
                        return View("Index", db.ShoppingCarts.Where(s => s.Member_ID == memberId).Include(s => s.Product).ToList());
                    }
                    cart.Quantity += quantity;
                }
                else
                {
                    ShoppingCart sc = new ShoppingCart
                    {
                        Member_ID = memberId,
                        Product_ID = id,
                        Quantity = quantity
                    };
                    db.ShoppingCarts.Add(sc);
                }

                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
        public ActionResult UpdateQuantity(int productId, int quantity)
        {
            if (Session["user"] != null)
            {
                int memberId = (Session["user"] as Member).ID;

                ShoppingCart cart = db.ShoppingCarts.FirstOrDefault(s => s.Member_ID == memberId && s.Product_ID == productId);

                if (cart != null)
                {
                    if (quantity > 0)
                    {
                        cart.Quantity = quantity;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeQuantity(int productId, bool increase)
        {
            if (Session["user"] != null)
            {
                int memberId = (Session["user"] as Member).ID;

                ShoppingCart cart = db.ShoppingCarts.FirstOrDefault(s => s.Member_ID == memberId && s.Product_ID == productId);
                Product product = db.Products.Find(productId); 

                if (cart != null && product != null)
                {
                    if (increase)
                    {
                        if (cart.Quantity + 1 > product.Stock) 
                        {
                            ViewBag.Error = $"Üzgünüz, '{product.Name}' ürünü için yeterli stok yok.";
                            return View("Index", db.ShoppingCarts.Where(s => s.Member_ID == memberId).Include(s => s.Product).ToList());
                        }
                        cart.Quantity++;
                    }
                    else if (cart.Quantity > 1)
                    {
                        cart.Quantity--;
                    }

                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCart(int productId)
        {
            if (Session["user"] != null)
            {
                int memberId = (Session["user"] as Member).ID;

                ShoppingCart cart = db.ShoppingCarts.FirstOrDefault(s => s.Member_ID == memberId && s.Product_ID == productId);

                if (cart != null)
                {
                    db.ShoppingCarts.Remove(cart);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}