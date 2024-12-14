using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class RegisterController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Member model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Members.FirstOrDefault(m => m.Mail == model.Mail);
                if (user != null)
                {
                    ViewBag.Warning = "Bu e-posta adresi zaten kullanılıyor.";
                    return View(model);
                }

                model.CreationTime = DateTime.Now;
                model.LastLoginTime = DateTime.Now;
                model.IsActive = true;
                db.Members.Add(model);
                db.SaveChanges();

                ViewBag.Success = "Kayıt başarılı! Giriş yapabilirsiniz.";
            }

            return View(model);
        }
    }
}