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

            if (Session["member"] != null)
            {
                Member m = (Member)Session["member"];
                Favorite fav = db.Favorites.FirstOrDefault(f => f.Product_ID == id && f.Member_ID == m.ID);
                if (fav != null)
                {
                    ViewBag.favorites = true;
                }
            }

            ViewBag.categories = db.Categories.Where(p => p.IsDeleted == false && p.IsActive == true).ToList();

            return View(model);
        }

        public ActionResult AddToFavorites(int id)
        {
            if (Session["member"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Member m = (Member)Session["member"];

            Favorite fav = new Favorite() { Product_ID = id, Member_ID = m.ID };
            db.Favorites.Add(fav);
            db.SaveChanges();

            return RedirectToAction("Detail", "Product", new { ID = id });
        }

        public ActionResult RemoveFromFavorites(int id)
        {
            Member m = (Member)Session["member"];
            int fid = db.Favorites.Where(f => f.Product_ID == id && f.Member_ID == m.ID).Select(f => f.ID).FirstOrDefault();
            Favorite fav = db.Favorites.Find(fid);

            db.Favorites.Remove(fav);
            db.SaveChanges();

            return RedirectToAction("Detail", "Product", new { ID = id });
        }
    }
}