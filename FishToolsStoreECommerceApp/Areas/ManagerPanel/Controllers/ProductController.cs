using FishToolsStoreECommerceApp.Areas.ManagerPanel.Filters;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class ProductController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: ManagerPanel/Product
        public ActionResult Index()
        {
            List<Product> products = db.Products.Where(p => p.IsDeleted == false).ToList();
            return View(products);
        }

        public ActionResult AllIndex()
        {
            return View(db.Products.ToList());
        }

        // GET: ManagerPanel/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerPanel/Product/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories.Where(c=> c.IsActive== true && c.IsDeleted== false), "ID", "Name");
            ViewBag.Brand_ID = new SelectList(db.Brands.Where(c => c.IsActive == true && c.IsDeleted == false), "ID", "Name");
            return View();
        }

        // POST: ManagerPanel/Product/Create
        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase productImage)
        {
            try
            {
                model.CreationTime = DateTime.Now;
                model.IsDeleted = false;
                model.Manager_ID = (Session["manager"] as Manager).ID;
                bool imageIsValid = false;
                if (productImage!= null)
                {
                    FileInfo fi = new FileInfo(productImage.FileName);
                    if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                    {
                        imageIsValid = true;
                        Guid filename = Guid.NewGuid();
                        string fullname = filename + fi.Extension;
                        productImage.SaveAs(Server.MapPath("~/Assets/ProductImages/"+fullname));
                        model.Image = fullname;
                    }
                }
                else
                {
                    imageIsValid = true;
                    model.Image = "none.png";
                }
                if (imageIsValid)
                {
                    db.Products.Add(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerPanel/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            Product p = db.Products.Find(id);
            if (p == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }

            ViewBag.Category_ID = new SelectList(db.Categories.Where(c => c.IsActive == true && c.IsDeleted == false), "ID", "Name",p.Category_ID);
            ViewBag.Brand_ID = new SelectList(db.Brands.Where(c => c.IsActive == true && c.IsDeleted == false), "ID", "Name", p.Brand_ID);
            return View(p);
        }

        // POST: ManagerPanel/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product model, HttpPostedFileBase productImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    if (productImage != null)
                    {
                        bool imageIsValid = false;
                        FileInfo fi = new FileInfo(productImage.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                        {
                            imageIsValid = true;
                            Guid filename = Guid.NewGuid();
                            string fullname = filename + fi.Extension;
                            productImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + fullname));
                            model.Image = fullname;
                        }
                        if (imageIsValid)
                        {
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: ManagerPanel/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Product");
            }
            Product prod = db.Products.Find(id);
            if (prod == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            return View(prod);
        }

        public ActionResult ReDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Brands");
            }
            Product prod = db.Products.Find(id);
            if (prod == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            prod.IsDeleted = false;
            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ManagerPanel/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product prod = db.Products.Find(id);
            prod.IsDeleted = true;
            prod.IsActive = false;
            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
