using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FishToolsStoreECommerceApp.Areas.ManagerPanel.Filters;
using FishToolsStoreECommerceApp.Models;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class BrandsController : Controller
    {
        private FishToolsStoreModel db = new FishToolsStoreModel();

        // GET: ManagerPanel/Brands
        public ActionResult Index()
        {
            return View(db.Brands.Where(b=> b.IsDeleted==false).ToList());
        }
        public ActionResult AllIndex()
        {
            return View(db.Brands.ToList());
        }

        // GET: ManagerPanel/Brands/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: ManagerPanel/Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Brands");
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            return View(brand);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IsActive,IsDeleted")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: ManagerPanel/Brands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Brands");
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            return View(brand);
        }
        public ActionResult ReDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Brands");
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            brand.IsDeleted = false;
            db.Entry(brand).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ManagerPanel/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            brand.IsDeleted = true;
            brand.IsActive = false;
            db.Entry(brand).State = EntityState.Modified;
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
