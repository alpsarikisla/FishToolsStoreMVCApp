using FishToolsStoreECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishToolsStoreECommerceApp.Areas.ManagerPanel.Controllers
{
    public class MemberController : Controller
    {
        FishToolsStoreModel db = new FishToolsStoreModel();

        // GET: ManagerPanel/Member
        public ActionResult Index()
        {
            return View(db.Members.Where(b => b.IsDeleted == false).ToList());

        }
        public ActionResult AllIndex()
        {
            return View(db.Members.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int id, bool isActive)
        {
            var member = db.Members.Find(id);
            if (member != null)
            {
                member.IsActive = !isActive;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Member");
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            return View(member);
        }
        public ActionResult ReDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Member");
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            member.IsDeleted = false;
            db.Entry(member).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            member.IsDeleted = true;
            member.IsActive = false;
            db.Entry(member).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}