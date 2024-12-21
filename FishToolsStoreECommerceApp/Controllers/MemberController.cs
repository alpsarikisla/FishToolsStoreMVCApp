using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Controllers
{
    public class MemberController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {

            Member user = Session["user"] as Member;

            if (user == null)
            {
                ViewBag.Warning = "Kullanıcı oturumunda bir hata oluştu.";
                return RedirectToAction("Index", "Home");
            }

            Member member = db.Members.Find(user.ID);

            if (member != null)
            {
                return View(member);
            }
            else
            {
                ViewBag.Warning = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member user)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Member member = db.Members.Find(user.ID);

                    if (member != null)
                    {
                        member.Name = user.Name;
                        member.Surname = user.Surname;
                        member.UserName = user.UserName;
                        member.Mail = user.Mail;
                        member.Password = user.Password;

                        db.Entry(member).State = EntityState.Modified;

                        if (db.SaveChanges() > 0)
                        {
                            Session["user"] = member;
                            ViewBag.Success = "Profil başarıyla güncellendi.";
                        }
                        else
                        {
                            ViewBag.Warning = "Veritabanı güncellemesi sırasında bir sorun oluştu.";
                        }
                    }
                    else
                    {
                        ViewBag.Warning = "Kullanıcı bulunamadı.";
                    }
                }
                catch
                {
                    ViewBag.Warning = "Bir hata oluştu. Lütfen tekrar deneyin.";
                }
            }
            else
            {
                ViewBag.Warning = "Girilen bilgilerde hata var. Lütfen kontrol edip tekrar deneyin.";
            }

            return View(user);
        }
    }
}
