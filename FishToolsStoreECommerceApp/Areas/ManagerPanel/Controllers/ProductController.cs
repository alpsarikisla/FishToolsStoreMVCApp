﻿using FishToolsStoreECommerceApp.Areas.ManagerPanel.Filters;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
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
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerPanel/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerPanel/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerPanel/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}