using FishToolsStoreECommerceApp.Areas.ManagerPanel.Data.ViewModels;
using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Controllers
{
    public class LoginController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: ManagerPanel/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ManagerLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager m = db.Managers.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["manager"] = m;
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
        public ActionResult Logout()
        {
            Session["manager"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}