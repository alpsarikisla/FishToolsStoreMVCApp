using FishToolsStoreECommerceApp.Data.ViewModels;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class LoginController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MemberLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Member m = db.Members.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["member"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.warning = "Kullanıcı hesabınız sistem yöneticisi tarafından askıya alınmıştır";
                    }
                }
                else
                {
                    ViewBag.warning = "Kullanıcı bulunamadı";
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member model)
        {
            if (ModelState.IsValid)
            {
                Member u = db.Members.FirstOrDefault(x => x.Mail == model.Mail);

                if (u != null)
                {
                    ViewBag.Warning = "Bu E-posta kullanılıyor!";
                    return View(model);
                }

                db.Members.Add(model);
                db.SaveChanges();

                Session["member"] = model;

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}