using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class ProductController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Product model = db.Products.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.categories = db.Categories.Where(p => p.IsDeleted == false && p.IsActive == true).ToList();

            var member = Session["user"] as Member;
            if (member != null)
            {
                var favorite = db.Favorites.FirstOrDefault(f => f.Member_ID == member.ID && f.Product_ID == model.ID);
                ViewBag.IsFavorite = favorite != null;
            }
            else
            {
                ViewBag.IsFavorite = false;
            }

            return View(model);
        }
        public ActionResult Favorites()
        {
            var member = Session["user"] as Member;
            if (member == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var favoriteProducts = db.Favorites
                                    .Where(f => f.Member_ID == member.ID)
                                    .Select(f => f.Product)
                                    .ToList();

            return View(favoriteProducts);
        }
        public ActionResult AddToFavorites(int productId)
        {
            var member = Session["user"] as Member;

            if (member != null)
            {
                var favorite = db.Favorites.FirstOrDefault(f => f.Member_ID == member.ID && f.Product_ID == productId);

                bool isFavorite;

                if (favorite == null)
                {
                    favorite = new Favorites
                    {
                        Member_ID = member.ID,
                        Product_ID = productId
                    };
                    db.Favorites.Add(favorite);
                    db.SaveChanges();
                    isFavorite = true;
                }
                else
                {
                    db.Favorites.Remove(favorite);
                    db.SaveChanges();
                    isFavorite = false;
                }

                return RedirectToAction("Detail", "Product", new { id = productId, isFavorite });
            }

            ViewBag.Warning = "Lütfen giriş yapın.";
            return RedirectToAction("Index", "Login");
        }

    }
}