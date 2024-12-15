using FishToolsStoreECommerceApp.Models;
using System;
using System.Data.Entity;
using System.IO;
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
            return View(db.Members.Where(m => m.IsDeleted == false).ToList());
        }

        public ActionResult AllIndex()
        {
            return View(db.Members.ToList());
        }

        public ActionResult EditStatus(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }

            Member m = db.Members.Find(id);

            if (m == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }

            m.IsActive = !m.IsActive;
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Member");
            }

            Member m = db.Members.Find(id);

            if (m == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }

            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member m = db.Members.Find(id);
            m.IsActive = false;
            m.IsDeleted = true;
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Member");
        }

        public ActionResult ReDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllIndex", "Member");
            }

            Member m = db.Members.Find(id);

            if (m == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }

            m.IsDeleted = false;
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Member");
        }

    }
}